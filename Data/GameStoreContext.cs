using System.Reflection;
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

    //After create GameConfiguration class, I implement this config here
    // by override the OnModelCreating method
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}