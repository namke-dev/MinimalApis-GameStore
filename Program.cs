using GameStoreApi.Data;
using GameStoreApi.EndPoints;
using GameStoreApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositoryService(builder.Configuration);


var app = builder.Build();

await app.Services.InitializeDbAsync();
app.MapGamesEndpoint();
app.Run();
