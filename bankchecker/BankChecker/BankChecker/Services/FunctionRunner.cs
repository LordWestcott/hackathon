using Services.Models.Domain;

namespace BankChecker.Services;

class FunctionRunner : IFunctionRunner
{
    private readonly ITransactionService _transactionService;
    private readonly IPaymentService _paymentService;
    private readonly IRoundingUpService _roundingUpService;
    private readonly IAccountService _accountService;
    private readonly IGameService _gameService;

    public FunctionRunner(ITransactionService transactionService, IPaymentService paymentService, IRoundingUpService roundingUpService, IAccountService accountService, IGameService gameService)
    {
        _transactionService = transactionService;
        _paymentService = paymentService;
        _roundingUpService = roundingUpService;
        _accountService = accountService;
        _gameService = gameService;
    }

    public async Task Run()
    {
        var userId = "1234";
        Console.WriteLine("Hi Im your friendly charity rounder upper");
        var accounts = await _accountService.GetAccounts();
        Console.WriteLine($"I have found {accounts.Count} accounts");
        var transactions = await GetAllTransactions(accounts);
        var roundUps = _roundingUpService.GetRoundUpTotal(transactions);

        Console.WriteLine(
            $"Rounding up {Math.Ceiling(roundUps)} pence from {transactions.Count} transactions, way to go!");
        await _gameService.AddRoundUpToUser(userId, roundUps, transactions);

        await _paymentService.SendPayment(new Payment { AccountNumber = "charity", SortCode = "sort", AmountInPence = (int)Math.Ceiling(roundUps * 100) });
    }

    private async Task<List<Transaction>> GetAllTransactions(List<Account> accounts)
    {
        double roundUpTotal = 0;
        int transactionCounter = 0;
        var transactions = new List<Transaction>();
        foreach (var account in accounts)
        {
            transactions.AddRange(await _transactionService.GetTransactions(account.Identifier));
            transactionCounter += transactions.Count;
        }
        return transactions;
    }
}