using Application.Extenstion;
using Application.Hubs;
using Hangfire;
using MediatR;
using Presistance.DataBase;
using Servers.Extentsion;
using Servers.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddDatabaseLayer(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentity();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.AddPolicys();
builder.Services.AddSignalR();
builder.Services.AddScoped<IUserSerive, UserService>();
builder.Services.AddHandFire(builder.Configuration);
builder.Services.AddMailConfig(builder.Configuration);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); 
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<Chat>("/chat");
app.Initialize(builder.Configuration);
app.AddMigrate();
app.UseHangfireServer();
app.UseHangfireDashboard("/hangfire", new DashboardOptions{ });
app.Run();
