using GameStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStoreApi.Data.Configurations;

//I get warning about EF Core dont know how to define the data type of the Price field of Game Model
//This config solve that
public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(game => game.Price).HasPrecision(5, 2);
        //Max posible value is 999.99
    }
}