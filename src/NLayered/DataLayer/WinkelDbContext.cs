﻿using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class WinkelDbContext : DbContext
    {
        public WinkelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Klant> Klanten { get; set; }

        public DbSet<Product> Producten { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
