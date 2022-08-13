
using Application.Config;
using Application.Conmon.Response.Identity;
using Application.Hubs;
using Application.Implementation;
using Application.Implementation.Service;
using Application.Repositery;
using Application.Repositery.Service;
using AutoMapper;
using Domain.Authentication;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Presistance.DataBase;
using Share.Permission;
using Share.Wapper;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Application.Extenstion
{
    public static class ServiceCollectionExtenstion
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(e => e.UseSqlServer(configuration.GetConnectionString("LeavePlatform")));
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService , UserService>();
            services.AddScoped<ITokenService, IdentityService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserClaimService, UserClaimService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IChat<UserResponse>, Chat>();

            return services;
        }
        public static IServiceCollection AddHandFire(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RouteOptions>(options => { options.LowercaseQueryStrings = true; });
            services.AddHangfire(configuration =>
            {
                configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                configuration.UseSimpleAssemblyNameTypeSerializer();
                configuration.UseRecommendedSerializerSettings();
                configuration.UseSqlServerStorage(config.GetConnectionString("LeavePlatform"));
            });
        
            return services;
        }
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
        public static AppConfig GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(AppConfig));
            services.Configure<AppConfig>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppConfig>();
        }
        public static MailConfiguration AddMailConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(nameof(MailConfiguration));
            services.Configure<MailConfiguration>(config);
            return config.Get<MailConfiguration>();
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews().AddNewtonsoftJson(op =>
                    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                   .AddNewtonsoftJson(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver());
            return services;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppConfig config)
        {
            var key = Encoding.UTF8.GetBytes(config.Secret!);

            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = true;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RoleClaimType = ClaimTypes.Role,
                    ClockSkew = TimeSpan.Zero
                };

                bearer.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = c =>
                    {
                        if (c.Exception is SecurityTokenExpiredException)
                        {
                            c.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            c.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(Response.Fail("The Token is expired."));
                            return c.Response.WriteAsync(result);
                        }
                        else
                        {
                            c.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            c.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(Response.Fail("An unhandled error has occurred."));
                            return c.Response.WriteAsync(result);
                        }
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(Response.Fail("You are not Authorized."));
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result =
                            JsonConvert.SerializeObject(Response.Fail("You are not authorized to access this resource."));
                        return context.Response.WriteAsync(result);
                    }
                };
            });

            services.AddHttpContextAccessor();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        public static IServiceCollection AddPolicys(this IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Permissions.Users.View, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.View));
                options.AddPolicy(Permissions.Users.SecretView, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.SecretView));
                options.AddPolicy(Permissions.Users.Delete, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.Delete));
                options.AddPolicy(Permissions.Users.Edit, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.Edit));
                options.AddPolicy(Permissions.Users.Create, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.Create));
                options.AddPolicy(Permissions.Users.CreateClaimRole, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.CreateClaimRole));
                options.AddPolicy(Permissions.Users.CreatePermissionRole, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.CreatePermissionRole));
                options.AddPolicy(Permissions.Users.CreateUserPermission, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Users.CreateUserPermission));


                options.AddPolicy(Permissions.Roles.View, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Roles.View));
                options.AddPolicy(Permissions.Roles.Edit, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Roles.Edit));
                options.AddPolicy(Permissions.Roles.Delete, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Roles.Delete));
                options.AddPolicy(Permissions.Roles.Create, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.Roles.Create));


                options.AddPolicy(Permissions.UserPermission.View, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.UserPermission.View));
                options.AddPolicy(Permissions.UserPermission.Edit, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.UserPermission.Edit));
                options.AddPolicy(Permissions.UserPermission.Create, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.UserPermission.Create));
                options.AddPolicy(Permissions.UserPermission.Delete, policy =>
                policy.RequireClaim(ApplicationClaimTypes.Permission, Permissions.UserPermission.Delete));

                //    Assembly assembly = Assembly.GetExecutingAssembly();
                //    var types = assembly.GetTypes()
                //                  .Where(t => String.Equals(t.Namespace, typeof(Permissions).Namespace, StringComparison.Ordinal))
                //                  .ToArray();
                //foreach (var type in types)
                //{
                //    var props = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                //    foreach (var t in props)
                //    {
                //        options.AddPolicy(t.Name, policy =>
                //        policy.RequireAssertion(context => context.User.HasClaim(c => c.Type == type.Name && c.Value == t.Name)));
                //    }
                //}

                //services.AddAuthorization(options =>
                //{
                //    var permissions = typeof(Permissions).GetNestedTypes().SelectMany(c =>
                //        c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy));
                //    // Here I stored necessary permissions/roles in a constant
                //    foreach (var prop in permissions)
                //    {
                //        var propertyValue = prop.GetValue(null);
                //        if (propertyValue is not null)
                //            options.AddPolicy(propertyValue.ToString(),
                //                policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
                //    }
                //});

            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
            return services;
        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LeaveForm v1",
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
