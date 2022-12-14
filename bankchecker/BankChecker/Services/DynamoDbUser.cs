using Services.Models;

namespace Services;

[DynamoDBTable("hackathon-money-game")]
public class DynamoDbUser
{
    [DynamoDBGlobalSecondaryIndexHashKey("User")]
    [DynamoDBRangeKey]
    public string sk { get; set; }
    [DynamoDBHashKey]
    public string pk { get; set; }
    public double TotalSoFar { get; set; }
    public int CurrentStreak { get; set; }
    [DynamoDBGlobalSecondaryIndexRangeKey("User")]
    public int LongestStreak { get; set; }
    public DateTime LastActivity { get; set; }
    public List<DynamoDbTransaction> Transactions { get; set; }
}