using System;
namespace ApplicationFromBoardGame.WebAPI.Settings
{
	public static class ApplicationFromBoardGameSettingsReader
	{
		public static ApplicationFromBoardGameSettings Read(IConfiguration configuration)
		{
            //здесь будет чтение настроек приложения из конфига
            return new ApplicationFromBoardGameSettings();
        }
	}
}