using Services.Models.Domain;

namespace BankChecker.Interfaces;

public interface IAccountService
{
    Task<List<Account>> GetAccounts();
}