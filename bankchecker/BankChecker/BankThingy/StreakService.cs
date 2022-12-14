using AutoMapper;
using Services;
using Services.Models.Domain;

namespace BankThingy;

class StreakService : IStreakService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public StreakService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<StreakDetails> GetUserStreak(string userid)
    {
        var userFromDb = await _userRepository.GetUserFromDb(userid);
        return _mapper.Map<StreakDetails>(userFromDb);
    }

    public async Task<List<StreakDetails>> GetStreaks()
    {
        var users = await _userRepository.GetUsersStreaks();
        return _mapper.Map<List<StreakDetails>>(users);
    }
}