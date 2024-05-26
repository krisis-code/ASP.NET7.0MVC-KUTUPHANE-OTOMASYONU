﻿using KitapKiralamaOtomasyonu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinemaOtomasyonu.Models;

namespace SinemaOtomasyonu.Utilitiy
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BookGenres> Genres { get; set; }

        public DbSet<Book> Books { get; set; }

		public DbSet<Borrow> Borrows { get; set; }
	}
}
