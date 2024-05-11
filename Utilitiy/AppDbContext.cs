using Microsoft.EntityFrameworkCore;

namespace SinemaOtomasyonu.Utilitiy
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
