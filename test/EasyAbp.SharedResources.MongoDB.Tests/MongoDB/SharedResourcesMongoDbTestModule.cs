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
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}