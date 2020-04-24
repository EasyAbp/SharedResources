using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.CategoryOwners;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    [ConnectionStringName(SharedResourcesDbProperties.ConnectionStringName)]
    public class SharedResourcesDbContext : AbpDbContext<SharedResourcesDbContext>, ISharedResourcesDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Category> Categories { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceItem> ResourceItems { get; set; }
        public DbSet<ResourceUser> ResourceUsers { get; set; }
        public DbSet<ResourceItemContent> ResourceItemContents { get; set; }
        public DbSet<CategoryOwner> CategoryOwners { get; set; }

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
