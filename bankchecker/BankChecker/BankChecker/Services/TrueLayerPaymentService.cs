using BankChecker.Models.TrueLayer;

namespace BankChecker.Services;

class TrueLayerPaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IConfigService _configService;
    private readonly ITruelayerAuthService _truelayerAuthService;

    public TrueLayerPaymentService(IMapper mapper, IConfigService configService, ITruelayerAuthService truelayerAuthService)
    {
        _mapper = mapper;
        _configService = configService;
        _truelayerAuthService = truelayerAuthService;
    }

    public async Task SendPayment(Payment payment)
    {
        var trueLayerRequest = _mapper.Map<PaymentRequest>(payment);
        var trueLayerDomain = _configService.GetValue(ConfigConstants.Domain);
        await $"https://{trueLayerDomain}/payments".WithOAuthBearerToken(_truelayerAuthService.GetToken("")).PostJsonAsync(trueLayerRequest);
    }
}