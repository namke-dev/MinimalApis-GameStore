using GameStoreApi.EndPoints;
using GameStoreApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register service game access, defie service fife time as Singleton
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

//use builder.Configuration to read value in appsetting.json
var connectionString = builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

app.MapGamesEndpoint();
app.Run();
