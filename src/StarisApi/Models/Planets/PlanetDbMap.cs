using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Planets;

public class PlanetDbMap : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("Planets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Climate).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Diameter).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Gravity).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.OrbitalPeriod).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Population).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.RotationSpeed).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.SurfaceWater).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Terrain).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnType("varchar(255)").IsRequired().HasDefaultValue(string.Empty);
    }
}
