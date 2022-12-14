namespace BankChecker.Services;

class ConfigService : IConfigService
{
    public string? GetValue(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }
}