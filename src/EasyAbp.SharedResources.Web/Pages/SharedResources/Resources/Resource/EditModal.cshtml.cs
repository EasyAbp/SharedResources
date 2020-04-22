using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource
{
    public class EditModalModel : SharedResourcesPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateResourceDto Resource { get; set; }

        private readonly IResourceAppService _service;

        public EditModalModel(IResourceAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            Resource = ObjectMapper.Map<ResourceDto, CreateUpdateResourceDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, Resource);
            return NoContent();
        }
    }
}