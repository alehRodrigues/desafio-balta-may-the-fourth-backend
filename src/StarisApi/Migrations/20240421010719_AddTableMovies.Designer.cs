﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarisApi.DbContexts;

#nullable disable

namespace StarisApi.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20240421010719_AddTableMovies")]
    partial class AddTableMovies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("StarisApi.Models.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Mass")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("StarisApi.Models.Movies.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Episode")
                        .HasColumnType("int")
                        .HasAnnotation("CheckConstraint", "CK_Episode_MinValue: Episode >= 1");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Movies", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
