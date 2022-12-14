using Services.Models.Domain;
using Services.Models.TrueLayer;

namespace BankChecker.Services;

public class TrueLayerTransactionService : ITransactionService
{
    private readonly IMapper _mapper;
    private readonly ITruelayerAuthService _authService;
    private readonly IConfigService _configService;

    public TrueLayerTransactionService(IMapper mapper, ITruelayerAuthService authService, IConfigService configService)
    {
        _mapper = mapper;
        _authService = authService;
        _configService = configService;
    }
    public async Task<List<Transaction>> GetTransactions(string accountId)
    {
        var trueLayerDomain = _configService.GetValue(ConfigConstants.TrueLayerApiDomain);
        var transactions = await $"https://{trueLayerDomain}/data/v1/accounts/{accountId}/transactions?from={Url.Encode(DateTime.Now.AddHours(-24).ToLongTimeString())}".WithOAuthBearerToken(await _authService.GetToken(accountId)).GetAsync();
        var jsonAsync = await transactions.GetJsonAsync<TrueLayerTransactionResponse>();
        return _mapper.Map<List<Transaction>>(jsonAsync.results.Where(x => x.amount < 0));
    }
}