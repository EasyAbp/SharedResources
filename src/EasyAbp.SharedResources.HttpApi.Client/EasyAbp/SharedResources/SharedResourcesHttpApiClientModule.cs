using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesApplicationContractsModule),
        typeof(AbpHttpClientModule)
    )]
    public class SharedResourcesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = SharedResourcesRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SharedResourcesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SharedResourcesApplicationContractsModule>();
            });
        }
    }
}
