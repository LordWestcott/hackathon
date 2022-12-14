namespace Services;

public interface IUserRepository
{
    Task SaveUserToDb(User user);
    Task<User> GetUserFromDb(string userId);
    Task<List<User>> GetUsersStreaks();
}