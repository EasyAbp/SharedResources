using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    [ConnectionStringName(SharedResourcesDbProperties.ConnectionStringName)]
    public interface ISharedResourcesDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}