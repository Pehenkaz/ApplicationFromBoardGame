using BoardGameCampaign.DataAccess;
using BoardGameCampaign.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameCampaign.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        Settings = BoardGameCampaignSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<BoardGameCampaignDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<BoardGameCampaignDbContext>(
            options => { options.UseSqlServer(Settings.BoardGameCampaignDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly BoardGameCampaignSettings Settings;
    protected readonly IDbContextFactory<BoardGameCampaignDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}