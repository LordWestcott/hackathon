namespace BankChecker.Interfaces;

public interface ITruelayerAuthService
{
    string GetToken(string accountId);
}