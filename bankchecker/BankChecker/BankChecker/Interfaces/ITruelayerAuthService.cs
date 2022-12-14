namespace BankChecker.Interfaces;

public interface ITruelayerAuthService
{
    Task<string> GetToken(string accountId);
    Task<string> GetNewAccessToken();
}