using BankChecker.Models;
using BankChecker.Models.TrueLayer;

namespace BankChecker.Mapping;

public class AutomapperProfile :Profile
{
    public AutomapperProfile()
    {
        CreateMap<Payment, PaymentRequest>().ForPath(x => x.payment_method.beneficiary.account_identifier.account_number, cfg => cfg.MapFrom(payment => payment.AccountNumber))
            .ForPath(x => x.payment_method.beneficiary.type, cfg => cfg.MapFrom(_ => "sort_code_account_number"))
            .ForPath(x => x.payment_method.beneficiary.account_identifier.sort_code, cfg => cfg.MapFrom(payment => payment.SortCode));
        CreateMap<Transaction, TrueLayerTransaction>();
        CreateMap<TrueLayerTransaction, Transaction>();
        CreateMap<TrueLayerAccount, Account>()
            .ForMember(x => x.Identifier, cfg => cfg.MapFrom(account => account.account_id));
    }
}