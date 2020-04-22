using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceUsers;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    [ConnectionStringName(SharedResourcesDbProperties.ConnectionStringName)]
    public interface ISharedResourcesDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Category> Categories { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<ResourceItem> ResourceItems { get; set; }
        DbSet<ResourceUser> ResourceUsers { get; set; }
        DbSet<ResourceItemContent> ResourceItemContents { get; set; }
    }
}
