namespace Services.Models.Domain;

public class StreakDetails
{
    public string UserId { get; set; }
    public int CurrentStreak { get; set; }
    public int LongestStreak { get; set; }
    public double TotalSoFar { get; set; }
}