using Microsoft.EntityFrameworkCore;
using WebAppPruebaTecnica.Entities;
using WebAppPruebaTecnica.Seed;
using WebAppPruebaTecnica.Models;

namespace WebAppPruebaTecnica.Models
{
    public class SalesDbContext : DbContext
    {

        public SalesDbContext(DbContextOptions<SalesDbContext> options): base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Provider> Providers { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleSeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new ProviderSeed());
        }
        public DbSet<WebAppPruebaTecnica.Models.ProductViewModel> ProductViewModel { get; set; } = default!;

    }
}
