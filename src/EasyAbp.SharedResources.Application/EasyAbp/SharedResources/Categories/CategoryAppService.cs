using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.CategoryOwners;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, GetCategoryListDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Categories.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Update;

        private readonly ICategoryOwnerManager _categoryOwnerManager;
        private readonly ICategoryDataPermissionProvider _categoryDataPermissionProvider;
        private readonly ICategoryRepository _repository;

        public CategoryAppService(
            ICategoryOwnerManager categoryOwnerManager,
            ICategoryDataPermissionProvider categoryDataPermissionProvider,
            ICategoryRepository repository) : base(repository)
        {
            _categoryOwnerManager = categoryOwnerManager;
            _categoryDataPermissionProvider = categoryDataPermissionProvider;
            _repository = repository;
        }

        protected override IQueryable<Category> CreateFilteredQuery(GetCategoryListDto input)
        {
            return _repository.GetQueryable(input.OwnerUserId).Where(x => x.ParentCategoryId == input.RootCategoryId);
        }

        public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var dto = await base.CreateAsync(input);
            
            await _categoryOwnerManager.AddCategoryOwnerAsync(dto.Id, CurrentUser.GetId());

            if (input.SetToCommon && await _categoryDataPermissionProvider.IsCurrentUserHasGlobalManagePermissionAsync())
            {
                await _categoryOwnerManager.AddCategoryOwnerAsync(dto.Id, null);
            }

            return dto;
        }

        public override async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            await CheckUpdatePolicyAsync();

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(id);

            var category = await GetEntityByIdAsync(id);

            if (input.SetToCommon && await _categoryDataPermissionProvider.IsCurrentUserHasGlobalManagePermissionAsync())
            {
                await _categoryOwnerManager.GetOrAddCategoryOwnerAsync(category.Id, null);
            }
            
            MapToEntity(input, category);
            
            await Repository.UpdateAsync(category, autoSave: true);

            return MapToGetOutputDto(category);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await CheckDeletePolicyAsync();

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(id);
            
            await Repository.DeleteAsync(id);

            await _categoryOwnerManager.RemoveAllCategoryOwnersAsync(id);
        }
    }
}