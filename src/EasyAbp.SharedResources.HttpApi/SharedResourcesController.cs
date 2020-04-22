using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.SharedResources
{
    public abstract class SharedResourcesController : AbpController
    {
        protected SharedResourcesController()
        {
            LocalizationResource = typeof(SharedResourcesResource);
        }
    }
}
