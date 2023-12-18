using GameStoreApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        //In the provided code, the using statement is used for the CreateScope(), 
        //which ensures that the scope is disposed of when the block is exited.
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await DbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositoryService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connectionString)
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

        return services;
    }
}