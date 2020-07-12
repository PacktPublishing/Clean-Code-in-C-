namespace CrossCuttingConcerns.Configuration
{
    public static class Settings
    {
        public static string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static void SetAppSettings(this string key, string value)
        {
            System.Configuration.ConfigurationManager.AppSettings[key] = value;
        }
    }
}
