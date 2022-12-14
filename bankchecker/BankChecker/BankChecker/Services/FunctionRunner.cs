namespace BankChecker.Services;

class FunctionRunner : IFunctionRunner
{
    private readonly ITransactionService _transactionService;
    private readonly IPaymentService _paymentService;
    private readonly IRoundingUpService _roundingUpService;
    private readonly IAccountService _accountService;

    public FunctionRunner(ITransactionService transactionService, IPaymentService paymentService, IRoundingUpService roundingUpService, IAccountService accountService)
    {
        _transactionService = transactionService;
        _paymentService = paymentService;
        _roundingUpService = roundingUpService;
        _accountService = accountService;
    }

    public async Task Run()
    {
        Console.WriteLine("Hi Im your friendly charity rounder upper");
        var accounts = await _accountService.GetAccounts();
        Console.WriteLine($"I have found {accounts.Count} accounts");
        double roundUpTotal = 0;
        int transactionCounter = 0;
        foreach (var account in accounts)
        {
            var transactions = await _transactionService.GetTransactions(account.Identifier);
            transactionCounter += transactions.Count;
            roundUpTotal += _roundingUpService.GetRoundUpTotal(transactions);
        }
        Console.WriteLine($"Rounding up {Math.Ceiling(roundUpTotal)} pence from {transactionCounter} transactions, way to go!");
        await _paymentService.SendPayment(new Payment()
            { AccountNumber = "charity", SortCode = "sort", AmountInPence = (int)Math.Ceiling(roundUpTotal * 100) });
    }
}