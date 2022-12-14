using BankChecker.Models;

namespace BankChecker.Interfaces;

public interface IRoundingUpService
{
    double GetRoundUpTotal(List<Transaction> transactions);
}