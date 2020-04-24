using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.CategoryOwners;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, GetCategoryListDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Categories.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Update;

        private readonly ICategoryDataPermissionProvider _categoryDataPermissionProvider;
        private readonly ICategoryOwnerRepository _categoryOwnerRepository;
        private readonly ICategoryRepository _repository;

        public CategoryAppService(
            ICategoryDataPermissionProvider categoryDataPermissionProvider,
            ICategoryOwnerRepository categoryOwnerRepository,
            ICategoryRepository repository) : base(repository)
        {
            _categoryDataPermissionProvider = categoryDataPermissionProvider;
            _categoryOwnerRepository = categoryOwnerRepository;
            _repository = repository;
        }

        protected override IQueryable<Category> CreateFilteredQuery(GetCategoryListDto input)
        {
            return _repository.GetQueryable(input.OwnerUserId).Where(x => x.ParentCategoryId == input.RootCategoryId);
        }

        public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var dto = await base.CreateAsync(input);
            
            await AddCategoryOwnerAsync(dto.Id, CurrentUser.GetId());

            if (input.IsCommon && await _categoryDataPermissionProvider.IsCurrentUserHasGlobalManagePermissionAsync())
            {
                await AddCategoryOwnerAsync(dto.Id, null);
            }

            return dto;
        }

        public override async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            await CheckUpdatePolicyAsync();

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(id);

            var category = await GetEntityByIdAsync(id);

            if (input.IsCommon && await _categoryDataPermissionProvider.IsCurrentUserHasGlobalManagePermissionAsync())
            {
                await GetOrAddCategoryOwnerAsync(category.Id, null);
            }
            
            MapToEntity(input, category);
            
            await Repository.UpdateAsync(category, autoSave: true);

            return MapToGetOutputDto(category);
        }

        private async Task<CategoryOwner> GetOrAddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            var categoryOwner =
                await _categoryOwnerRepository.FindAsync(
                    x => x.CategoryId == categoryId && x.OwnerUserId == ownerUserId);

            return categoryOwner ?? await AddCategoryOwnerAsync(categoryId, ownerUserId);
        }

        private async Task<CategoryOwner> AddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            return await _categoryOwnerRepository.InsertAsync(new CategoryOwner(GuidGenerator.Create(), CurrentTenant.Id,
                categoryId, ownerUserId));
        }

        public override async Task DeleteAsync(Guid id)
        {
            await CheckDeletePolicyAsync();

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(id);
            
            await Repository.DeleteAsync(id);
        }
    }
}