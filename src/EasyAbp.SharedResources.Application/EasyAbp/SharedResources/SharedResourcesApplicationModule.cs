using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.BackgroundJobs;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesDomainModule),
        typeof(SharedResourcesApplicationContractsModule),
        typeof(AbpBackgroundJobsAbstractionsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpMapperlyModule)
        )]
    public class SharedResourcesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMapperlyObjectMapper<SharedResourcesApplicationModule>();
        }
    }
}
