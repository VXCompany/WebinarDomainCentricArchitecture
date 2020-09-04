using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class WinkelDbContext : DbContext
    {
        public DbSet<Klant> Klanten { get; set; }

        public DbSet<Produkt> Produkten { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Winkel;Integrated Security=True");
        }
    }
}
