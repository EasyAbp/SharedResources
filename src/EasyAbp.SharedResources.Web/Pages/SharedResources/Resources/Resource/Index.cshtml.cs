using System.Threading.Tasks;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource
{
    public class IndexModel : SharedResourcesPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
