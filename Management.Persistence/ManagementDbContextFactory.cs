using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Management.Persistence
{
    public class ManagementDbContextFactory : IDesignTimeDbContextFactory<ManagementdbContext>
    {
        public ManagementdbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ManagementdbContext>();
            var connectionString = config.GetConnectionString("ManagementConnectionString");
                
            builder.UseSqlServer(connectionString);

            return new ManagementdbContext(builder.Options);
        }
    }
}
