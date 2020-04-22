using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.SharedResources.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class SharedResourcesPageModel : AbpPageModel
    {
        protected SharedResourcesPageModel()
        {
            LocalizationResourceType = typeof(SharedResourcesResource);
            ObjectMapperContext = typeof(SharedResourcesWebModule);
        }
    }
}