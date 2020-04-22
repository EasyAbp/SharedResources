using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category
{
    public class IndexModel : SharedResourcesPageModel
    {
        private readonly ICategoryAppService _categoryAppService;

        [BindProperty(SupportsGet = true)]
        public Guid? OwnerUserId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public Guid? RootCategoryId { get; set; }
        
        public string RootCategoryName { get; set; }

        public IndexModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        
        public async Task OnGetAsync()
        {
            if (RootCategoryId.HasValue)
            {
                var categoryDto = await _categoryAppService.GetAsync(RootCategoryId.Value);

                RootCategoryName = categoryDto.Name;
            }
        }
    }
}
