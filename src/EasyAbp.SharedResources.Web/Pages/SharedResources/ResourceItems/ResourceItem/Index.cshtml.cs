using System.Threading.Tasks;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem
{
    public class IndexModel : SharedResourcesPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
