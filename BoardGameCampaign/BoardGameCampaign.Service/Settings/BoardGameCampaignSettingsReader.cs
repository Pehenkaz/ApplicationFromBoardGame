using System;
using BoardGameCampaign.Service.Settings;

namespace BoardGameCampaign.Service.Settings
{
    public static class BoardGameCampaignSettingsReader
    {
        public static BoardGameCampaignSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new BoardGameCampaignSettings()
            {
                BoardGameCampaignDbContextConnectionString = configuration.GetValue<string>("BoardGameCampaignDbContext")
            };
        }
    }
}