using Microsoft.EntityFrameworkCore;
using GamingStoreApi.Models;

namespace GamingStoreApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Place>().ToTable("Place");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}