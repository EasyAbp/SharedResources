using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.SharedResources.Pages
{
    public class IndexModel : SharedResourcesPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}