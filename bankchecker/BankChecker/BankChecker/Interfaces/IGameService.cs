using Services.Models.Domain;

namespace BankChecker.Interfaces;

public interface IGameService
{
    Task AddRoundUpToUser(string userId, double roundup, List<Transaction> transactions);
}