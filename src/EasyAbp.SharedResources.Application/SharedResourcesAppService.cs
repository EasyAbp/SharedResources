using EasyAbp.SharedResources.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources
{
    public abstract class SharedResourcesAppService : ApplicationService
    {
        protected SharedResourcesAppService()
        {
            LocalizationResource = typeof(SharedResourcesResource);
            ObjectMapperContext = typeof(SharedResourcesApplicationModule);
        }
    }
}
