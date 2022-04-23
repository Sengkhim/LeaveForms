using Application.Extenstion;
using Hangfire;
using MediatR;
using Presistance.DataBase;
using Servers.Extentsion;
using Servers.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddDatabaseLayer(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentity();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.AddPolicys();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHandFire(builder.Configuration);
builder.Services.AddMailConfig(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHangfireServer();
app.Initialize(builder.Configuration);
app.UseHangfireDashboard("/hangfire", new DashboardOptions{ });
app.Run();
