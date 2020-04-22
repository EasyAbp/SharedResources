using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    public class SharedResourcesHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SharedResourcesHttpApiHostMigrationsDbContext>
    {
        public SharedResourcesHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SharedResourcesHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("SharedResources"));

            return new SharedResourcesHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
