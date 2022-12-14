namespace BankChecker.Services;

public interface IConfigService
{
    string? GetValue(string key);
}