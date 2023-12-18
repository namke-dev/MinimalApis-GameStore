using GameStoreApi.EndPoints;
using GameStoreApi.Repository;

var builder = WebApplication.CreateBuilder(args);
// Register service game access, defie service fife time as Scope
builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();
var app = builder.Build();

app.MapGamesEndpoint();
app.Run();
