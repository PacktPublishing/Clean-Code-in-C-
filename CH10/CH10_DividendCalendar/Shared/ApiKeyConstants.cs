namespace CH10_DividendCalendar.Shared
{
    public struct ApiKeyConstants
    {
        public const string HeaderName = "X-Api-Key";
        public const string MorningstarApiKeyUrl = "https://<KEY_VAULT_NAME>.vault.azure.net/secrets/MorningstarApiKey";
        public const int ThrottleMonthDay = 25;
    }
}
