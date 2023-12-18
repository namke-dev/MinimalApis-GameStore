using GameStoreApi.Entities;
using GameStoreApi.Repository;

namespace GameStoreApi.EndPoints;

public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoint(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/games")
        .WithParameterValidation();

        group.MapGet("/", async (IGamesRepository repository) =>
            (await repository.GetAllAsync()).Select(s => s.AsDto()));

        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            var game = await repository.GetAsync(id);
            return (game is null) ? Results.NotFound() : Results.Ok(game.AsDto());
        })
        .WithName(GetGameEndPointName);

        group.MapPost("/", async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            var game = new Game
            {
                Name = gameDto.Name,
                Genres = gameDto.Genres,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto gameDto) =>
        {
            Game? existingGame = await repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = gameDto.Name;
            existingGame.Genres = gameDto.Genres;
            existingGame.Price = gameDto.Price;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.ImageUri = gameDto.ImageUri;


            await repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? existingGame = await repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            await repository.DeleteAsync(id);
            return Results.NoContent();
        });

        return group;
    }
}
