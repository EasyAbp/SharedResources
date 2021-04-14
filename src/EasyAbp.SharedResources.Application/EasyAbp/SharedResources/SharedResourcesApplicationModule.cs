using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
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
        typeof(AbpAutoMapperModule)
        )]
    public class SharedResourcesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SharedResourcesApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SharedResourcesApplicationModule>(validate: true);
            });
        }
    }
}
