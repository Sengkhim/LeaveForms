using Application.Repositery;
using Microsoft.EntityFrameworkCore;
using Presistance.DataBase;

namespace Servers.Extentsion
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder Initialize(this IApplicationBuilder app, IConfiguration _configuration)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var init = serviceScope.ServiceProvider.GetServices<IDatabaseSeeder>();

            foreach (var initializer in init) initializer.Initialize();

            return app;
        }
        
        /// <summary>
        /// Represent for add migration table to database when run application
        /// This context use for migration table to database image in docker.
        /// </summary>
        /// <param name="builder"></param>
        public static void AddMigrate(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            var db = serviceScope.ServiceProvider.GetRequiredService<IDataContext>().Database;
            logger.LogInformation("Migrating database...");
            while (!db.CanConnect())
            {
                logger.LogInformation("Database not ready yet; waiting...");
                Thread.Sleep(1000); 
            }
            try
            {
                serviceScope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
                logger.LogInformation("Database migrated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
