using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.SharedResources.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class SharedResourcesDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SharedResourcesDomainSharedModule>("EasyAbp.SharedResources");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<SharedResourcesResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/SharedResources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("SharedResources", typeof(SharedResourcesResource));
            });
        }
    }
}
