using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources.MongoDB
{
    [DependsOn(
        typeof(SharedResourcesTestBaseModule),
        typeof(SharedResourcesMongoDbModule)
        )]
    public class SharedResourcesMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}