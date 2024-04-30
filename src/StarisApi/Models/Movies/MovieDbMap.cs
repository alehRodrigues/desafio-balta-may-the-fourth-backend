using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarisApi.Models.Movies;

public class MovieDbMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Producer).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.Director).HasColumnType("varchar(50)").IsRequired();
        builder
            .Property(x => x.Episode)
            .HasColumnType("int")
            .IsRequired()
            .HasAnnotation("CheckConstraint", "CK_Episode_MinValue: Episode >= 1");
        builder.Property(x => x.OpeningCrawl).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.ReleaseDate).HasColumnType("varchar(50)").IsRequired();
        builder.Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();
        builder
            .Property(x => x.ImageUrl)
            .HasColumnType("varchar(255)")
            .IsRequired()
            .HasDefaultValue(string.Empty);
    }
}
