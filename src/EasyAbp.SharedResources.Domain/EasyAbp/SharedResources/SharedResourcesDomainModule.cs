using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.Resources;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesDomainSharedModule)
        )]
    public class SharedResourcesDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<Resource>();
                options.AutoEventSelectors.Add<ResourceItem>();
            });
        }
    }
}
