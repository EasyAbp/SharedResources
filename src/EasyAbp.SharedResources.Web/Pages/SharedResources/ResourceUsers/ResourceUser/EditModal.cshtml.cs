using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceUsers.Dtos;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser
{
    public class EditModalModel : SharedResourcesPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateResourceUserDto ResourceUser { get; set; }

        private readonly IResourceUserAppService _service;

        public EditModalModel(IResourceUserAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ResourceUser = ObjectMapper.Map<ResourceUserDto, CreateUpdateResourceUserDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ResourceUser);
            return NoContent();
        }
    }
}