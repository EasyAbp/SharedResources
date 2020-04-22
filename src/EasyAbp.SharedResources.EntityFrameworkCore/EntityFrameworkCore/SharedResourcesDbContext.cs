using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    [ConnectionStringName(SharedResourcesDbProperties.ConnectionStringName)]
    public class SharedResourcesDbContext : AbpDbContext<SharedResourcesDbContext>, ISharedResourcesDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public SharedResourcesDbContext(DbContextOptions<SharedResourcesDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureSharedResources();
        }
    }
}