using GameStoreApi.Data;
using GameStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Repository;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Games.AsNoTracking().ToList();
    }
    public Game? Get(int id)
    {
        return dbContext.Games.Find(id);
    }
    public void Create(Game game)
    {
        dbContext.Games.Add(game);
        //Save change to DB
        dbContext.SaveChanges();
    }
    public void Update(Game updatedGame)
    {
        dbContext.Games.Update(updatedGame);
        dbContext.SaveChanges();
    }
    public void Delete(int id)
    {
        dbContext.Games.Where(game => game.Id == id).ExecuteDelete();
    }
}