using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarisApi.Models.StarShips;

namespace StarisApi.Models.Starships;

public class StarshipDbMap : IEntityTypeConfiguration<Starship>
{
    public void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.ToTable("Starships");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Model).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.CargoCapacity).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Consumables).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.CostInCredits).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Crew).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.HyperDriveRating).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Lenght).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Manufacturer).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.MaxAtmospheringSpeed).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Megalights).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Passengers).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.StarshipClass).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnType("varchar(255)").IsRequired().HasDefaultValue(string.Empty);
    }
}
