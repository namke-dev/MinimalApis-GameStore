using GameStoreApi.Entities;

namespace GameStoreApi.EndPoints;

public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    static List<Game> games = new(){
            new Game(){
                Id = 1,
                Name = "Street Fighter II",
                Genres = "Fighting",
                Price = 11.99M,
                ReleaseDate = new DateTime(1991, 2, 1),
                ImageUri = "https://placehold.co/100"
            },
            new Game(){
                Id = 2,
                Name = "Megaman X4",
                Genres = "Platform",
                Price = 11.99M,
                ReleaseDate = new DateTime(1999, 2, 1),
                ImageUri = "https://placehold.co/100"
            },
            new Game(){
                Id = 3,
                Name = "Mario Bros II",
                Genres = "Fighting",
                Price = 9.99M,
                ReleaseDate = new DateTime(2001, 2, 1),
                ImageUri = "https://placehold.co/100"
            },
            new Game(){
                Id = 4,
                Name = "Final Fanstasy XIV",
                Genres = "Roleplaying",
                Price = 11.99M,
                ReleaseDate = new DateTime(2010, 3, 29),
                ImageUri = "https://placehold.co/100"
            },
            new Game(){
                Id = 5,
                Name = "FIFA 11",
                Genres = "Sports",
                Price = 39.99M,
                ReleaseDate = new DateTime(2016, 5, 14),
                ImageUri = "https://placehold.co/100"
            }
};

    public static RouteGroupBuilder MapGamesEndpoint(this IEndpointRouteBuilder route)
    {

        var group = route.MapGroup("/games")
        .WithParameterValidation();

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(s => s.Id == id);
            return (game is null) ? Results.NotFound() : Results.Ok(game);
        })
        //Named this route
        .WithName(GetGameEndPointName);

        group.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(s => s.Id) + 1;
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
            //new { id = game.Id } is a anonymous type 
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            var oldGame = games.Find(s => s.Id == id);
            if (oldGame is null)
            {
                return Results.NotFound();
            }
            updatedGame.Id = oldGame.Id;
            games.Remove(oldGame);
            games.Add(updatedGame);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            var oldGame = games.Find(s => s.Id == id);
            if (oldGame is null)
            {
                return Results.NotFound();
            }
            games.Remove(oldGame);
            return Results.NoContent();
        });

        return group;
    }
}
