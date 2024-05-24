﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SinemaOtomasyonu.Utilitiy;

#nullable disable

namespace SinemaOtomasyonu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240524174921_ImageUrlAdd")]
    partial class ImageUrlAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KitapKiralamaOtomasyonu.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookGenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("BookGenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SinemaOtomasyonu.Models.BookGenres", b =>
                {
                    b.Property<Guid>("BookGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookGenreName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("BookGenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("KitapKiralamaOtomasyonu.Models.Book", b =>
                {
                    b.HasOne("SinemaOtomasyonu.Models.BookGenres", "BookGenres")
                        .WithMany()
                        .HasForeignKey("BookGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
