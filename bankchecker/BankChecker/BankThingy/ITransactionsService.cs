namespace BankThingy;

public interface ITransactionsService
{
    Task<TransactionResponse> GetTransactions(string userId);
}