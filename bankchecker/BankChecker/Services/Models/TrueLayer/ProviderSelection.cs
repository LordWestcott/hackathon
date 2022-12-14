namespace Services.Models.TrueLayer;

public class ProviderSelection
{
    public string type { get; set; }
    public Filter filter { get; set; }
    public SchemeSelection scheme_selection { get; set; }
    public Remitter remitter { get; set; }
}