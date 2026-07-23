using System;
using EasyAbp.SharedResources.Categories.Dtos;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryAppServiceTests : SharedResourcesApplicationTestBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IObjectMapper<SharedResourcesApplicationModule> _objectMapper;

        public CategoryAppServiceTests()
        {
            _categoryAppService = GetRequiredService<ICategoryAppService>();
            _objectMapper = GetRequiredService<IObjectMapper<SharedResourcesApplicationModule>>();
        }

        [Fact]
        public void Should_Map_Category_To_CategoryDto()
        {
            var parentId = Guid.NewGuid();
            var category = new Category(Guid.NewGuid(), parentId, "MyCategory", "mark");

            var dto = _objectMapper.Map<Category, CategoryDto>(category);

            dto.ParentCategoryId.ShouldBe(parentId);
            dto.Name.ShouldBe("MyCategory");
            dto.CustomMark.ShouldBe("mark");
        }
    }
}
