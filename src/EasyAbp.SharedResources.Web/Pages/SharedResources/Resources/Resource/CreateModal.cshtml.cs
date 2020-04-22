using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateUpdateResourceDto Resource { get; set; }

        private readonly IResourceAppService _service;

        public CreateModalModel(IResourceAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(Resource);
            return NoContent();
        }
    }
}