using GameStoreApi.Entities;

namespace GameStoreApi.Repository;

interface IGamesRepository
{
    public IEnumerable<Game> GetAll();
    public Game? Get(int id);
    public void Create(Game game);
    public void Update(Game updatedGame);
    public void Delete(int id);
}
