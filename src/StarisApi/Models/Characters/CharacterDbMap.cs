using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Characters;

public class CharacterDbMap : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.BirthYear).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.EyeColor).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Gender).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.HairColor).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Height).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.Mass).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.SkinColor).HasColumnType("varchar(30)").IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnType("varchar(255)").IsRequired().HasDefaultValue(string.Empty);
    }
}
