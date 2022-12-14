// <auto-generated />
using System;
using Links_Cards.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Links_Cards.Migrations
{
    [DbContext(typeof(CardsDbContext))]
    partial class CardsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Links_Cards.Models.Card_Raw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CardAlias")
                        .HasColumnType("longtext");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<float?>("Credit")
                        .HasColumnType("float");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
