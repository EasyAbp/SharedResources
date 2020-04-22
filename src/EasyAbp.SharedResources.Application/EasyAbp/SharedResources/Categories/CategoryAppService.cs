using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, GetCategoryListDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Categories.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Update;
        protected override string GetPolicyName { get; set; } = SharedResourcesPermissions.Categories.Default;
        protected override string GetListPolicyName { get; set; } = SharedResourcesPermissions.Categories.Default;
        
        private readonly ICategoryRepository _repository;

        public CategoryAppService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<Category> CreateFilteredQuery(GetCategoryListDto input)
        {
            return base.CreateFilteredQuery(input).Where(x =>
                x.ParentCategoryId == input.RootCategoryId && x.OwnerUserId == input.OwnerUserId);
        }

        public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.OwnerUserId);
            
            return await base.CreateAsync(input);
        }
        
        public override async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.OwnerUserId);

            await CheckUpdatePolicyAsync();

            var category = await GetEntityByIdAsync(id);

            if (category.OwnerUserId != input.OwnerUserId)
            {
                await CheckCurrentUserAllowedToModifyAsync(category.OwnerUserId);
            }
            
            MapToEntity(input, category);
            
            await Repository.UpdateAsync(category, autoSave: true);

            return MapToGetOutputDto(category);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var category = await GetEntityByIdAsync(id);
            
            await CheckCurrentUserAllowedToModifyAsync(category.OwnerUserId);

            await base.DeleteAsync(id);
        }

        protected virtual async Task CheckCurrentUserAllowedToModifyAsync(Guid? categoryOwnerUserId)
        {
            if (!await IsCurrentUserOwnerOrAdminAsync(categoryOwnerUserId))
            {
                throw new AbpAuthorizationException();
            }
        }
        
        protected virtual async Task<bool> IsCurrentUserOwnerOrAdminAsync(Guid? categoryOwnerUserId)
        {
            return CurrentUser.Id.HasValue && CurrentUser.Id.Value == categoryOwnerUserId ||
                   await AuthorizationService.IsGrantedAsync(SharedResourcesPermissions.Categories.GlobalManage);
        }
    }
}