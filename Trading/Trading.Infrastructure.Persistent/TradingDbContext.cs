using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Trading.Infrastructure.Data.Model;

namespace Trading.Infrastructure.Persistent
{
    public class TradingDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Wallet> Wallet { get; set; }

        public TradingDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration.GetConnectionString("HerokuWebApiDatabase"),
                ServerVersion.AutoDetect(Configuration.GetConnectionString("HerokuWebApiDatabase"))
            );
        }
    }
}
