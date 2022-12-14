using Services.Models.Domain;

namespace BankThingy;

public interface IStreakService
{
    Task<StreakDetails> GetUserStreak(string userid);
    Task<List<StreakDetails>> GetStreaks();
}