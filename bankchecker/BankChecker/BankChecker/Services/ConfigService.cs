using Microsoft.Extensions.Configuration;

namespace BankChecker.Services;

class ConfigService : IConfigService
{
    private readonly IConfigurationRoot configRoot;

    public ConfigService()
    {
        configRoot =  new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
    } 
    public string? GetValue(string key)
    {
        return configRoot.GetSection(key).Value;
    }
}