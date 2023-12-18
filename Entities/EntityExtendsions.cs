namespace GameStoreApi.Entities;

public static class EntityExtendsions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genres,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }
}