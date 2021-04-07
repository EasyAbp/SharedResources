using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.CategoryOwners;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceUsers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceAppService : CrudAppService<Resource, ResourceDto, Guid, GetResourceListDto, CreateUpdateResourceDto, CreateUpdateResourceDto>,
        IResourceAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Resources.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Update;

        private readonly ICategoryDataPermissionProvider _categoryDataPermissionProvider;
        private readonly IResourceItemRepository _resourceItemRepository;
        private readonly IResourceUserRepository _resourceUserRepository;
        private readonly IResourceRepository _repository;

        public ResourceAppService(
            ICategoryDataPermissionProvider categoryDataPermissionProvider,
            IResourceItemRepository resourceItemRepository,
            IResourceUserRepository resourceUserRepository,
            IResourceRepository repository) : base(repository)
        {
            _categoryDataPermissionProvider = categoryDataPermissionProvider;
            _resourceItemRepository = resourceItemRepository;
            _resourceUserRepository = resourceUserRepository;
            _repository = repository;
        }

        public override async Task<ResourceDto> GetAsync(Guid id)
        {
            var resource = await GetEntityByIdAsync(id);
            
            if (!resource.IsPublished && !await _categoryDataPermissionProvider.IsCurrentUserAllowedToManageAsync(resource.CategoryId))
            {
                throw new EntityNotFoundException(typeof(Resource), id);
            }

            var dto = await MapToGetOutputDtoAsync(resource);

            dto.IsAuthorized = CurrentUser.IsAuthenticated &&
                               await _resourceUserRepository.FindAsync(id, CurrentUser.GetId()) != null;

            return dto;
        }
        
        public override async Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourceListDto input)
        {
            var query = (await _repository.GetQueryableWithAuthorizationStatusAsync(CurrentUser.Id, input.AuthorizedOnly))
                .Where(x => x.Resource.CategoryId == input.CategoryId);

            if (!await _categoryDataPermissionProvider.IsCurrentUserAllowedToManageAsync(input.CategoryId))
            {
                query = query.Where(x => x.Resource.IsPublished);
            }

            var totalCount = await AsyncExecuter.CountAsync(query);
            
            query = query.PageBy(input);

            var resources = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<ResourceDto>(
                totalCount,
                resources.Select(x =>
                {
                    var dto = ObjectMapper.Map<Resource, ResourceDto>(x.Resource);
                    dto.IsAuthorized = x.IsAuthorized;
                    return dto;
                }).ToList()
            );
        }
        
        [Authorize]
        public virtual async Task<PagedResultDto<ResourceDto>> GetListAuthorizedAsync(PagedAndSortedResultRequestDto input)
        {
            var query =
                (await _repository.GetUserAuthorizedOnlyQueryableAsync(CurrentUser.GetId())).Where(x => x.IsPublished);
            
            var totalCount = await AsyncExecuter.CountAsync(query);

            var getResourceListDto = input as GetResourceListDto;

            query = ApplySorting(query, getResourceListDto);
            query = ApplyPaging(query, getResourceListDto);

            var resources = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<ResourceDto>(
                totalCount,
                resources.Select(x =>
                {
                    var dto = ObjectMapper.Map<Resource, ResourceDto>(x);
                    dto.IsAuthorized = true;
                    return dto;
                }).ToList()
            );
        }

        public override async Task<ResourceDto> CreateAsync(CreateUpdateResourceDto input)
        {
            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(input.CategoryId);
            
            return await base.CreateAsync(input);
        }
        
        public override async Task<ResourceDto> UpdateAsync(Guid id, CreateUpdateResourceDto input)
        {
            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(input.CategoryId);

            await CheckUpdatePolicyAsync();

            var resource = await GetEntityByIdAsync(id);

            if (resource.CategoryId != input.CategoryId)
            {
                await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);
            }
            
            await MapToEntityAsync(input, resource);
            
            await Repository.UpdateAsync(resource, autoSave: true);

            return await MapToGetOutputDtoAsync(resource);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await CheckDeletePolicyAsync();
            
            var resource = await GetEntityByIdAsync(id);
            
            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);

            await _resourceItemRepository.DeleteAsync(x => x.ResourceId == id, true);

            await _resourceUserRepository.DeleteAsync(x => x.ResourceId == id, true);

            await base.DeleteAsync(id);
        }

    }
}