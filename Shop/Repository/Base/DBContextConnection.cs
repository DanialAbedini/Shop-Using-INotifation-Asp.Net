using Microsoft.EntityFrameworkCore;
using Shop.Models.Domain;

namespace Shop.Repository.Base
{
    public class DBContextConnection:DbContext
    {
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9GMOCTB;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
