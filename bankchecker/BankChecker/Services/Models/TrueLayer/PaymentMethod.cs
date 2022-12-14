namespace Services.Models.TrueLayer;

public class PaymentMethod
{
    public string type { get; set; }
    public ProviderSelection provider_selection { get; set; }
    public Beneficiary beneficiary { get; set; }
}