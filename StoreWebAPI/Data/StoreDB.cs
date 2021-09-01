using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Data.Configurations;

namespace StoreWebAPI.Data
{
    public class StoreDB : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

        
        public StoreDB(DbContextOptions options) : base(options)
        {           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TwoEF_Test; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
