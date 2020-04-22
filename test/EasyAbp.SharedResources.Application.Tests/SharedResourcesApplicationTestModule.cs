using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesApplicationModule),
        typeof(SharedResourcesDomainTestModule)
        )]
    public class SharedResourcesApplicationTestModule : AbpModule
    {

    }
}
