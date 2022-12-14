using BankChecker.Models;

namespace BankChecker.Interfaces;

public interface ITransactionService
{
    Task<List<Transaction>> GetTransactions(string accountId);
}