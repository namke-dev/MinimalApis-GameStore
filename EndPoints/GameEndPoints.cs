using GameStoreApi.Entities;
using GameStoreApi.Repository;

namespace GameStoreApi.EndPoints;

public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoint(this IEndpointRouteBuilder route)
    {
        InMemGamesRepository repository = new();
        var group = route.MapGroup("/games")
        .WithParameterValidation();

        group.MapGet("/", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            var game = repository.Get(id);
            return (game is null) ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndPointName);

        group.MapPost("/", (Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            updatedGame.Id = id;
            repository.Update(updatedGame);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            repository.Delete(id);
            return Results.NoContent();
        });

        return group;
    }
}
