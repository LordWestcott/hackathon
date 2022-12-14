using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using BankThingy;
using Services;
using Services.Mapping;
using Services.Models.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserRepository, DynamoDbUserRepository>();
builder.Services.AddSingleton<ITransactionsService, TransactionsService>();
builder.Services.AddSingleton<IStreakService, StreakService>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddDefaultAWSOptions(new AWSOptions());
builder.Services.AddAWSService<AmazonDynamoDBClient>();
var app = builder.Build();
app.MapGet("/transactions", async (string userid) => await app.Services.GetService<ITransactionsService>().GetTransactions(userid));
app.MapGet("/userstreaks", async (string userid) => await app.Services.GetService<IStreakService>().GetUserStreak(userid));
app.MapGet("/streaks", async () => await app.Services.GetService<IStreakService>().GetStreaks());

app.Run();