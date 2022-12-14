namespace BankChecker.Interfaces;

public interface IConfigService
{
    string? GetValue(string key);
}