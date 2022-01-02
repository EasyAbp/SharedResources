using EasyAbp.SharedResources.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.SharedResources
{
    [Area(SharedResourcesRemoteServiceConsts.ModuleName)]
    public abstract class SharedResourcesController : AbpControllerBase
    {
        protected SharedResourcesController()
        {
            LocalizationResource = typeof(SharedResourcesResource);
        }
    }
}
