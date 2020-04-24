using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser.ViewModels;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateEditResourceUserViewModel ResourceUser { get; set; }

        private readonly IResourceUserAppService _service;

        public CreateModalModel(IResourceUserAppService service)
        {
            _service = service;
        }
        
        public virtual async Task OnGetAsync(Guid resourceId)
        {
            ResourceUser = new CreateEditResourceUserViewModel
            {
                ResourceId = resourceId
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateEditResourceUserViewModel, CreateUpdateResourceUserDto>(ResourceUser));
            
            return NoContent();
        }
    }
}