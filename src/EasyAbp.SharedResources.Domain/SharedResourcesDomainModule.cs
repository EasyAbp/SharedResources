using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesDomainSharedModule)
        )]
    public class SharedResourcesDomainModule : AbpModule
    {

    }
}
