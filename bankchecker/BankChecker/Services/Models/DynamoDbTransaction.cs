namespace Services.Models;

public class DynamoDbTransaction
{
    public double Amount { get; set; }
    public double RoundUpAmount { get; set; }
    public DateTime Date { get; set; }
}