using Microsoft.EntityFrameworkCore;

namespace wms.core.Models
{
    public class WMSContext : DbContext
    {
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLines> orderLines { get; set; }

        public WMSContext(DbContextOptions<WMSContext> options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfigurationsFromAssembly(typeof(WMSContext).Assembly);
        //     //base.OnModelCreating(modelBuilder);
        // }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("localhost");
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WMSDb;User Id=SA;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False;");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}