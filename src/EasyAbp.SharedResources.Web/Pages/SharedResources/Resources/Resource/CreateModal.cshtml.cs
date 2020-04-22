using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateEditResourceViewModel Resource { get; set; }

        private readonly IResourceAppService _service;

        public CreateModalModel(IResourceAppService service)
        {
            _service = service;
        }
        
        public virtual async Task OnGetAsync(Guid? ownerUserId, Guid? categoryId)
        {
            Resource = new CreateEditResourceViewModel
            {
                OwnerUserId = ownerUserId,
                CategoryId = categoryId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateEditResourceViewModel, CreateUpdateResourceDto>(Resource));
            
            return NoContent();
        }
    }
}