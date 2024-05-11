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
    [Migration("20240511123911_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SinemaOtomasyonu.Models.BookGenres", b =>
                {
                    b.Property<Guid>("BookGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookGenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookGenreId");

                    b.ToTable("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
