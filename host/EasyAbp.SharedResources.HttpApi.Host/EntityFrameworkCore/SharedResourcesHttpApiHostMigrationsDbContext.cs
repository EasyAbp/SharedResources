using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    public class SharedResourcesHttpApiHostMigrationsDbContext : AbpDbContext<SharedResourcesHttpApiHostMigrationsDbContext>
    {
        public SharedResourcesHttpApiHostMigrationsDbContext(DbContextOptions<SharedResourcesHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSharedResources();
        }
    }
}
