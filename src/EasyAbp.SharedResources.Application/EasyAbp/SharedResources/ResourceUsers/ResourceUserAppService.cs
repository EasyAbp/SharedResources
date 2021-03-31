using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.CategoryOwners;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUserAppService : CrudAppService<ResourceUser, ResourceUserDto, Guid, GetResourceUserListDto, CreateUpdateResourceUserDto, CreateUpdateResourceUserDto>,
        IResourceUserAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.ResourceUsers.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.ResourceUsers.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.ResourceUsers.Update;
        protected override string GetPolicyName { get; set; } = SharedResourcesPermissions.ResourceUsers.Default;
        protected override string GetListPolicyName { get; set; } = SharedResourcesPermissions.ResourceUsers.Default;

        private readonly ICategoryDataPermissionProvider _categoryDataPermissionProvider;
        private readonly IResourceRepository _resourceRepository;
        private readonly IResourceUserRepository _repository;

        public ResourceUserAppService(
            ICategoryDataPermissionProvider categoryDataPermissionProvider,
            IResourceRepository resourceRepository,
            IResourceUserRepository repository) : base(repository)
        {
            _categoryDataPermissionProvider = categoryDataPermissionProvider;
            _resourceRepository = resourceRepository;
            _repository = repository;
        }
        
        protected override IQueryable<ResourceUser> CreateFilteredQuery(GetResourceUserListDto input)
        {
            return base.CreateFilteredQuery(input).Where(x => x.ResourceId == input.ResourceId);
        }
        
        public override async Task<ResourceUserDto> GetAsync(Guid id)
        {
            var dto = await base.GetAsync(id);
            
            var resource = await _resourceRepository.GetAsync(dto.ResourceId);

            if (!await _categoryDataPermissionProvider.IsCurrentUserAllowedToManageAsync(resource.CategoryId))
            {
                throw new EntityNotFoundException(typeof(ResourceUser), id);
            }

            return dto;
        }

        public override async Task<PagedResultDto<ResourceUserDto>> GetListAsync(GetResourceUserListDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);
            
            if (!await _categoryDataPermissionProvider.IsCurrentUserAllowedToManageAsync(resource.CategoryId))
            {
                throw new EntityNotFoundException(typeof(Resource), input.ResourceId);
            }

            return await base.GetListAsync(input);
        }

        public override async Task<ResourceUserDto> CreateAsync(CreateUpdateResourceUserDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);
            
            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);
            
            return await base.CreateAsync(input);
        }

        public override async Task<ResourceUserDto> UpdateAsync(Guid id, CreateUpdateResourceUserDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);
            
            return await base.UpdateAsync(id, input);
        }
        
        public virtual async Task<ResourceUserDto> UpdateExtraPropertiesAsync(Guid id, UpdateResourceUserExtraPropertiesInput input)
        {
            await CheckUpdateExtraPropertiesPolicyAsync();
            
            var resourceUser = await GetEntityByIdAsync(id);

            if (resourceUser.UserId != CurrentUser.GetId() &&
                !await AuthorizationService.IsGrantedAsync(SharedResourcesPermissions.ResourceUsers.GlobalManage))
            {
                throw new AbpAuthorizationException();
            }
            
            input.MapExtraPropertiesTo(resourceUser);

            await _repository.UpdateAsync(resourceUser, true);

            return await MapToGetOutputDtoAsync(resourceUser);
        }

        protected virtual async Task CheckUpdateExtraPropertiesPolicyAsync()
        {
            await AuthorizationService.CheckAsync(SharedResourcesPermissions.ResourceUsers.UpdateExtraProperties);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var resourceUser = await GetEntityByIdAsync(id);
            
            var resource = await _resourceRepository.GetAsync(resourceUser.ResourceId);

            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);

            await base.DeleteAsync(id);
        }
    }
}