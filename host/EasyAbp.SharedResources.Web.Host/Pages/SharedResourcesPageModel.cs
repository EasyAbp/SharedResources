using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.SharedResources.Pages
{
    public abstract class SharedResourcesPageModel : AbpPageModel
    {
        protected SharedResourcesPageModel()
        {
            LocalizationResourceType = typeof(SharedResourcesResource);
        }
    }
}