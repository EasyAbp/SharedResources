using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SharedResourcesConsoleApiClientModule : AbpModule
    {
        
    }
}
