using Microsoft.EntityFrameworkCore;
using Lab_3.Models;

namespace Lab_3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<PortfolioAsset> PortfolioAssets => Set<PortfolioAsset>();

        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloap.db");
        }
    }
}
