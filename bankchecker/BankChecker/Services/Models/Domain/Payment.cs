namespace Services.Models.Domain;

public class Payment
{
    public string AccountNumber { get; set; }
    public string SortCode { get; set; }
    public int AmountInPence { get; set; }
}