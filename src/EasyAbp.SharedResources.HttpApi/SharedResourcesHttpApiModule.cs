using Localization.Resources.AbpUi;
using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class SharedResourcesHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SharedResourcesHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SharedResourcesResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
