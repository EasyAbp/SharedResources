using System.Threading.Tasks;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category
{
    public class CreateModalModel : SharedResourcesPageModel
    {
        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

        private readonly ICategoryAppService _service;

        public CreateModalModel(ICategoryAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(Category);
            return NoContent();
        }
    }
}