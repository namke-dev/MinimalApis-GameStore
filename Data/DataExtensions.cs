using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DbContext.Database.Migrate();
        //This has same effect as run .NET CLI to run EF migrate 
    }
}