using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem.ViewModels;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateEditResourceItemViewModel ResourceItem { get; set; }

        private readonly IResourceItemAppService _service;

        public CreateModalModel(IResourceItemAppService service)
        {
            _service = service;
        }
        
        public virtual async Task OnGetAsync(Guid resourceId)
        {
            ResourceItem = new CreateEditResourceItemViewModel
            {
                ResourceId = resourceId
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateEditResourceItemViewModel, CreateUpdateResourceItemDto>(ResourceItem));
            
            return NoContent();
        }
    }
}