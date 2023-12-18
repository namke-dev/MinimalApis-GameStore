using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        //In the provided code, the using statement is used for the CreateScope(), 
        //which ensures that the scope is disposed of when the block is exited.
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DbContext.Database.Migrate();
        //This has same effect as run .NET CLI to run EF migrate 
    }
}