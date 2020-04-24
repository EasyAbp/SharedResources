using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource
{
    public class EditModalModel : SharedResourcesPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditResourceViewModel Resource { get; set; }

        private readonly IResourceAppService _service;

        public EditModalModel(IResourceAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            Resource = ObjectMapper.Map<ResourceDto, CreateEditResourceViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id,
                ObjectMapper.Map<CreateEditResourceViewModel, CreateUpdateResourceDto>(Resource));
            
            return NoContent();
        }
    }
}