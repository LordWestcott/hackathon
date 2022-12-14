using Services.Models;

namespace BankChecker.Services;

class TruelayerAuthService : ITruelayerAuthService
{
    private readonly IConfigService _configService;

    public TruelayerAuthService(IConfigService configService)
    {
        _configService = configService;
    }

    private string accessToken = "";
    private string refreshToken = "00C26842CBF4A53E869A5DBA773B68C7839AF88B954DF1BFA933E1AAE084F276";
    public async Task<string> GetNewAccessToken()
    {
        var postJsonAsync = await $"https://{_configService.GetValue(ConfigConstants.TrueLayerAuthDomain)}/connect/token".PostJsonAsync(new TokenRequest
        {
            client_id = _configService.GetValue(ConfigConstants.ClientId), 
            client_secret = _configService.GetValue(ConfigConstants.ClientSecret), 
            grant_type = "refresh_token", 
            refresh_token = refreshToken
        });
        var tokenResponse = await postJsonAsync.GetJsonAsync<TokenResponse>();
        accessToken = tokenResponse.access_token;
        refreshToken = tokenResponse.refresh_token;
        return accessToken;
    }

    public async Task<string> GetToken(string accountId)
    {
        if (string.IsNullOrEmpty(accessToken))
            return await GetNewAccessToken();
        return accessToken;
    }
}