using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceItems.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateUpdateResourceItemDto ResourceItem { get; set; }

        private readonly IResourceItemAppService _service;

        public CreateModalModel(IResourceItemAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ResourceItem);
            return NoContent();
        }
    }
}