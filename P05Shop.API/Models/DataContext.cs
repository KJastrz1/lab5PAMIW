using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext CreateContext()
        {
            throw new NotImplementedException();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Barcode).IsRequired().HasMaxLength(12);

            modelBuilder.Entity<Product>().Property(p => p.Title).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(8,2)");

            modelBuilder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(8,2)");

            modelBuilder
                .Entity<Order>()
                .Property(o => o.Date)
                .IsRequired()
                .HasColumnType("datetime2");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Order>().HasKey(o => o.Id);

            modelBuilder.Entity<Product>().HasData(ProductSeeder.GenerateProductData());
            modelBuilder.Entity<Order>().HasData(OrderSeeder.GenerateOrderData());
        }
    }
}

