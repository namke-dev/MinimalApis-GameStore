using GameStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions options)
    : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();
}