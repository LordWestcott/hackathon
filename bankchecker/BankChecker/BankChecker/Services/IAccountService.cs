namespace BankChecker.Services;

public interface IAccountService
{
    Task<List<Account>> GetAccounts();
}