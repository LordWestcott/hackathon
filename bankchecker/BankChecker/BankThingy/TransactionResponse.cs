using Services.Models.Domain;

namespace BankThingy;

public class TransactionResponse
{
    public IList<Transaction> RecentTransactions { get; set; }
    public string UserId { get; set; }
    public Dictionary<string,double> TotalAmountDonatedInMonths { get; set; }
}