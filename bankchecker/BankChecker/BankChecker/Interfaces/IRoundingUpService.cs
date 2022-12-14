using Services.Models.Domain;

namespace BankChecker.Interfaces;

public interface IRoundingUpService
{
    double GetRoundUpTotal(List<Transaction> transactions);
}