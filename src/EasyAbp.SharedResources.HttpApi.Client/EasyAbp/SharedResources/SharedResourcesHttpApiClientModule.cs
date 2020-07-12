using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SharedResourcesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyAbpSharedResources";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SharedResourcesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
