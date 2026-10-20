using Microsoft.EntityFrameworkCore;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //локальная SQLite
            optionsBuilder.UseSqlite("Data Source=ef_shop.db");
        }
    }
}
