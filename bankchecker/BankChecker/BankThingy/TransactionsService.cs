using Services;

namespace BankThingy;

public class TransactionsService : ITransactionsService
{
    private readonly IUserRepository _userRepository;

    public TransactionsService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<TransactionResponse> GetTransactions(string userId)
    {
        var user = await _userRepository.GetUserFromDb(userId);
        return new TransactionResponse()
        {
            UserId = user.UserId,
            RecentTransactions = user.Transactions.Where(x => x.Date > DateTime.Now.AddDays(-30)).ToList(),
            TotalAmountDonatedInMonths = user.Transactions.GroupBy(x => x.Date.Month + "/" + x.Date.Year)
                .ToDictionary(x => x.Key, x => x.Select(y => Math.Ceiling(y.Amount) - y.Amount).Sum())
        };
    }
}