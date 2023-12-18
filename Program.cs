using GameStoreApi.Data;
using GameStoreApi.EndPoints;
using GameStoreApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register service game access, 
// defie service fife time as Singleton
builder.Services.AddSingleton<IGamesRepository, EntityFrameworkGamesRepository>();

// Use builder.Configuration to read value in appsetting.json
var connectionString = builder.Configuration.GetConnectionString("GameStoreContext");

// Register EF service - The AddSqlServer method just like AddScope or AddSingleton, but we let EF handle it, but we can config those in DbContextOptions
builder.Services.AddSqlServer<GameStoreContext>(connectionString);

var app = builder.Build();

app.Services.InitializeDb();
app.MapGamesEndpoint();
app.Run();
