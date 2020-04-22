using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceUsers.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateUpdateResourceUserDto ResourceUser { get; set; }

        private readonly IResourceUserAppService _service;

        public CreateModalModel(IResourceUserAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ResourceUser);
            return NoContent();
        }
    }
}