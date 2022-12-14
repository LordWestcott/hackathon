using Services.Models.Domain;

namespace Services;

public class User
{
    public string UserId { get; set; }
    public double TotalSoFar { get; set; }
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public DateTime LastActivity { get; set; }
    public List<Transaction> Transactions { get; set; }
}