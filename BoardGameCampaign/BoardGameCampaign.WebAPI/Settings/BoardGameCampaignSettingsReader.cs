using System;
using BoardGameCampaign.WebAPI.Settings;

namespace BoardGameCampaign.WebAPI.Settings
{
    public static class BoardGameCampaignSettingsReader
    {
        public static BoardGameCampaignSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new BoardGameCampaignSettings();
        }
    }
}