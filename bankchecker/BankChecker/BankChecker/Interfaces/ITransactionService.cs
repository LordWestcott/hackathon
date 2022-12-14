using Services.Models.Domain;

namespace BankChecker.Interfaces;

public interface ITransactionService
{
    Task<List<Transaction>> GetTransactions(string accountId);
}