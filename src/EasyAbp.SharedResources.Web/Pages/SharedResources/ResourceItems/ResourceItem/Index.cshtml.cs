using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem
{
    public class IndexModel : SharedResourcesPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid ResourceId { get; set; }
        
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
