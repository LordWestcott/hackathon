using BankChecker.Models;

namespace BankChecker.Services;

public class RoundingUpService : IRoundingUpService
{
    public double GetRoundUpTotal(List<Transaction> transactions)
    {
        return transactions.Select(x => Math.Ceiling(x.Amount) - x.Amount).Sum();
    }
}