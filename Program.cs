using GameStoreApi.Data;
using GameStoreApi.EndPoints;
using GameStoreApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositoryService(builder.Configuration);


var app = builder.Build();

app.Services.InitializeDb();
app.MapGamesEndpoint();
app.Run();
