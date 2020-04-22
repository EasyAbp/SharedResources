using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.SharedResources.MongoDB
{
    [ConnectionStringName(SharedResourcesDbProperties.ConnectionStringName)]
    public interface ISharedResourcesMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
