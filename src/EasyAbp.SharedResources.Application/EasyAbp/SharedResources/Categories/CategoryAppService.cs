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

        protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(GetCategoryListDto input)
        {
            var query = (await _repository.GetQueryableAsync(input.OwnerUserId))
                .Where(x => x.ParentCategoryId == input.RootCategoryId);

            return input.CustomMark != null ? query.Where(x => x.CustomMark == input.CustomMark) : query;
        }

        public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            await CheckCreatePolicyAsync();
            
            if (input.ParentCategoryId.HasValue)
            {
                await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(input.ParentCategoryId.Value);
            }
            
            var category = await MapToEntityAsync(input);

            TryToSetTenantId(category);

            await Repository.InsertAsync(category, autoSave: true);

            await _categoryOwnerManager.AddCategoryOwnerAsync(category.Id, CurrentUser.GetId());

            if (input.SetToCommon && await _categoryDataPermissionProvider.IsCurrentUserHasGlobalManagePermissionAsync())
            {
                await _categoryOwnerManager.AddCategoryOwnerAsync(category.Id, null);
            }

            return await MapToGetOutputDtoAsync(category);
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
            
            await MapToEntityAsync(input, category);
            
            await Repository.UpdateAsync(category, autoSave: true);

            return await MapToGetOutputDtoAsync(category);
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