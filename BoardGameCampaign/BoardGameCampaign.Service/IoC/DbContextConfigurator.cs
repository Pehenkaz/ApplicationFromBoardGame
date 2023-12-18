using BoardGameCampaign.DataAccess;
using BoardGameCampaign.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace BoardGameCampaign.Service.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, BoardGameCampaignSettings settings)
        {
            services.AddDbContextFactory<BoardGameCampaignDbContext>(
                options => { options.UseSqlServer(settings.BoardGameCampaignDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BoardGameCampaignDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
        }
    }
}