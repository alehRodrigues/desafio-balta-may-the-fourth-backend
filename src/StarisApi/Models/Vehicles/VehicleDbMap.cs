using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Vehicles
{
    public class VehicleDbMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Model).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.CargoCapacity).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Consumables).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.CostInCredits).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Crew).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Passengers).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Lenght).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Manufacturer).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.MaxAtmospheringSpeed).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.VehicleClass).HasColumnType("varchar(30)").IsRequired();
            builder
                .Property(x => x.ImageUrl)
                .HasColumnType("varchar(255)")
                .IsRequired()
                .HasDefaultValue(string.Empty);
        }
    }
}
