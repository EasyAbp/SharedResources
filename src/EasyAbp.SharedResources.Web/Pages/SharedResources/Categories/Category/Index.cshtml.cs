using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category
{
    public class IndexModel : SharedResourcesPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid? OwnerUserId { get; set; }
        
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
