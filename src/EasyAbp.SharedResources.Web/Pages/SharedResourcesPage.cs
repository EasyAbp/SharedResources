using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.SharedResources.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits EasyAbp.SharedResources.Web.Pages.SharedResourcesPage
     */
    public abstract class SharedResourcesPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<SharedResourcesResource> L { get; set; }
    }
}
