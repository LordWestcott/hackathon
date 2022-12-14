namespace Services.Models.Domain;

public class Transaction
{
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public double RoundUpAmount { get; set; }

}