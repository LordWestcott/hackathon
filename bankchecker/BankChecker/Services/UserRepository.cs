namespace Services;

public class DynamoDbUserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly DynamoDBContext context;

    public DynamoDbUserRepository(IMapper mapper)
    {
        _mapper = mapper;

        var client = new AmazonDynamoDBClient();
        context = new DynamoDBContext(client);
    }
    public async Task SaveUserToDb(User user)
    {
        var dynamoUser = _mapper.Map<DynamoDbUser>(user);
        await context.SaveAsync(dynamoUser);
    }
    public async Task<User> GetUserFromDb(string userId)
    {
        var filter = new QueryFilter();
        filter.AddCondition("pk", QueryOperator.Equal, userId);
        var queryOperationConfig = new QueryOperationConfig(){Filter = filter, Select = SelectValues.AllAttributes};
        var dynamoDbUsers = await context.FromQueryAsync<DynamoDbUser>(queryOperationConfig).GetRemainingAsync();
        if (dynamoDbUsers.Count == 0)
            return new User() { UserId = userId };
        var dynamoDbUser = dynamoDbUsers.First();
        return _mapper.Map<User>(dynamoDbUser);
    }

    public async Task<List<User>> GetUsersStreaks()
    {
        var filter = new QueryFilter();
        filter.AddCondition("sk", QueryOperator.Equal, "USER");
        var queryOperationConfig = new QueryOperationConfig(){Filter = filter, Select = SelectValues.AllAttributes, IndexName = "User"};
        var dynamoDbUsers = await context.FromQueryAsync<DynamoDbUser>(queryOperationConfig).GetRemainingAsync();
        return _mapper.Map<List<User>>(dynamoDbUsers);
    }
}