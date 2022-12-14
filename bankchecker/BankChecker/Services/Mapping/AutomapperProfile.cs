using Services.Models;
using Services.Models.Domain;
using Services.Models.TrueLayer;

namespace Services.Mapping;

public class AutomapperProfile :Profile
{
    public AutomapperProfile()
    {
        CreateMap<User, DynamoDbUser>().ForMember(x => x.pk, cfg => cfg.MapFrom(user => user.UserId))
            .ForMember(x => x.sk, cfg => cfg.MapFrom(user => "USER"));
        CreateMap<DynamoDbUser, User>().ForMember(x => x.UserId, cfg => cfg.MapFrom(user => user.pk));
        CreateMap<Payment, PaymentRequest>().ForPath(x => x.payment_method.beneficiary.account_identifier.account_number, cfg => cfg.MapFrom(payment => payment.AccountNumber))
            .ForPath(x => x.payment_method.beneficiary.type, cfg => cfg.MapFrom(_ => "sort_code_account_number"))
            .ForPath(x => x.payment_method.beneficiary.account_identifier.sort_code, cfg => cfg.MapFrom(payment => payment.SortCode));
        CreateMap<TrueLayerTransaction, Transaction>().ForMember(x => x.Date, cfg => cfg.MapFrom(trans => trans.timestamp));
        CreateMap<Transaction, DynamoDbTransaction>().ForMember(x => x.RoundUpAmount,
            cfg => cfg.MapFrom(trans => Math.Ceiling(Math.Abs(trans.Amount)) - Math.Abs(trans.Amount)));
        CreateMap<TrueLayerAccount, Account>()
            .ForMember(x => x.Identifier, cfg => cfg.MapFrom(account => account.account_id));
        CreateMap<DynamoDbTransaction, Transaction>();
        CreateMap<User, StreakDetails>();
        CreateMap<StreakDetails, User>();

    }
}