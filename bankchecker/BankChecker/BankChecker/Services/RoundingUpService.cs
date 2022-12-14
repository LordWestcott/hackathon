using Services.Models.Domain;

namespace BankChecker.Services;

public class RoundingUpService : IRoundingUpService
{
    public double GetRoundUpTotal(List<Transaction> transactions)
    {
        return transactions.Select(x => Math.Ceiling(Math.Abs(x.Amount)) - Math.Abs(x.Amount)).Sum();
    }
}