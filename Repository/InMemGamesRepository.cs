using GameStoreApi.Entities;

namespace GameStoreApi.Repository;
public class InMemGamesRepository : IGamesRepository
{

    private List<Game> games = new(){
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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(s => s.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(s => s.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(s => s.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(s => s.Id == id);
        games.RemoveAt(index);
    }

}