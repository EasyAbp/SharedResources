using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateEditCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _service;

        public CreateModalModel(ICategoryAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync(Guid? ownerUserId, Guid? parentCategoryId)
        {
            Category = new CreateEditCategoryViewModel
            {
                OwnerUserId = ownerUserId,
                ParentCategoryId = parentCategoryId
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(Category));
            
            return NoContent();
        }
    }
}