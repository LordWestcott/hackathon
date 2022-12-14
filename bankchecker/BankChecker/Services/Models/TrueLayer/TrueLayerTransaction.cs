namespace Services.Models.TrueLayer;

public class TrueLayerTransaction
{
    public string transaction_id { get; set; }
    public double amount { get; set; }
    public DateTime timestamp { get; set; }
}