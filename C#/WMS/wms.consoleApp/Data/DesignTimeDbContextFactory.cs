using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using wms.core.Models;

namespace wms.consoleaApp.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WMSContext>
    {
        public WMSContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<WMSContext>();
            var connectionString = configuration.GetConnectionString("WMSDatabase");
            optionsBuilder.UseSqlServer(connectionString);

            return new WMSContext(optionsBuilder.Options);
        }
    }
}
