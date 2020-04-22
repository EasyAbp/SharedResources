using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceItems.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem
{
    public class EditModalModel : SharedResourcesPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateResourceItemDto ResourceItem { get; set; }

        private readonly IResourceItemAppService _service;

        public EditModalModel(IResourceItemAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ResourceItem = ObjectMapper.Map<ResourceItemDto, CreateUpdateResourceItemDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ResourceItem);
            return NoContent();
        }
    }
}