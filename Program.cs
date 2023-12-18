using GameStoreApi.EndPoints;
using GameStoreApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register service game access, defie service fife time as Singleton
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var app = builder.Build();

app.MapGamesEndpoint();
app.Run();
