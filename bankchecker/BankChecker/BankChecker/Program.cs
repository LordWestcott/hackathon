using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Services;
using Services.Mapping;

ServiceCollection sc = new ServiceCollection();
sc.AddSingleton<IPaymentService, TrueLayerPaymentService>();
sc.AddSingleton<IRoundingUpService, RoundingUpService>();
sc.AddSingleton<ITransactionService, TrueLayerTransactionService>();
sc.AddSingleton<ITruelayerAuthService, TruelayerAuthService>();
sc.AddSingleton<IFunctionRunner, FunctionRunner>();
sc.AddSingleton<IConfigService, ConfigService>();
sc.AddSingleton<IAccountService, TruelayerAccountService>();
sc.AddSingleton<IGameService, GameService>();
sc.AddDefaultAWSOptions(new AWSOptions());
sc.AddAWSService<AmazonDynamoDBClient>();
sc.AddSingleton<IUserRepository, DynamoDbUserRepository>();
sc.AddTransient<IDynamoDBContext, DynamoDBContext>();

sc.AddAutoMapper(typeof(AutomapperProfile));
var functionRunner = sc.BuildServiceProvider().GetService<IFunctionRunner>();
await functionRunner.Run();
Console.WriteLine("Hello, World!");