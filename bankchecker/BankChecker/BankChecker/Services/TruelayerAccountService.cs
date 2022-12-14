using Services.Models.Domain;
using Services.Models.TrueLayer;

namespace BankChecker.Services;

public class TruelayerAccountService : IAccountService
{
    private readonly IConfigService _configService;
    private readonly IMapper _mapper;
    private readonly ITruelayerAuthService _truelayerAuthService;

    public TruelayerAccountService(IConfigService configService, IMapper mapper, ITruelayerAuthService truelayerAuthService)
    {
        _configService = configService;
        _mapper = mapper;
        _truelayerAuthService = truelayerAuthService;
    }
    public async Task<List<Account>> GetAccounts()
    {
        var jsonAsync = await $"https://{_configService.GetValue(ConfigConstants.TrueLayerApiDomain)}/data/v1/accounts".WithOAuthBearerToken(await _truelayerAuthService.GetToken(""))
            .GetJsonAsync<TrueLayerAccountResponse>();
        return _mapper.Map<List<Account>>(jsonAsync.results);
    }
}