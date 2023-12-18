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

        group.MapGet("/", (IGamesRepository repository) => repository.GetAllAsync().Select(s => s.AsDto()));

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            var game = repository.GetAsync(id);
            return (game is null) ? Results.NotFound() : Results.Ok(game.AsDto());
        })
        .WithName(GetGameEndPointName);

        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            var game = new Game
            {
                Name = gameDto.Name,
                Genres = gameDto.Genres,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };

            repository.CreateAsync(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto gameDto) =>
        {
            Game? existingGame = repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = gameDto.Name;
            existingGame.Genres = gameDto.Genres;
            existingGame.Price = gameDto.Price;
            existingGame.ReleaseDate = gameDto.ReleaseDate;
            existingGame.ImageUri = gameDto.ImageUri;


            repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? existingGame = repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            repository.DeleteAsync(id);
            return Results.NoContent();
        });

        return group;
    }
}
