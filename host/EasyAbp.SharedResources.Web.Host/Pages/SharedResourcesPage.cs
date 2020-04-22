using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.SharedResources.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.SharedResources.Pages
{
    public abstract class SharedResourcesPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<SharedResourcesResource> L { get; set; }
    }
}
