using Application.Repositery;

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
    }
}
