using Services;
using Services.Models.Domain;

namespace BankChecker.Services;
public class GameService : IGameService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IDynamoDBContext context;

    public GameService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task AddRoundUpToUser(string userId, double roundup, List<Transaction> transactions)
    {
        var user = await _userRepository.GetUserFromDb(userId);
        UpdateUser(roundup, user, transactions);
        await _userRepository.SaveUserToDb(user);
    }

    private void UpdateUser(double roundup, User user, List<Transaction> transactions)
    {
        user.Transactions = transactions;
        user.TotalSoFar += roundup;
        if (user.LastActivity == null || user.LastActivity < DateTime.Now.AddDays(-7))
            user.CurrentStreak = 1;
        else
            user.CurrentStreak += 1;
        user.LastActivity = DateTime.Now;
        if (user.LongestStreak <= user.CurrentStreak)
            user.LongestStreak = user.CurrentStreak;
    }
}