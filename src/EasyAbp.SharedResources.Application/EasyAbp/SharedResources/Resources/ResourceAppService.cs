using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.CategoryOwners;
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
        private readonly IResourceUserRepository _resourceUserRepository;
        private readonly IResourceRepository _repository;

        public ResourceAppService(
            ICategoryDataPermissionProvider categoryDataPermissionProvider,
            IResourceUserRepository resourceUserRepository,
            IResourceRepository repository) : base(repository)
        {
            _categoryDataPermissionProvider = categoryDataPermissionProvider;
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

            var dto = MapToGetOutputDto(resource);

            dto.IsAuthorized = await _resourceUserRepository.FindAsync(id, CurrentUser.GetId()) != null;

            return dto;
        }
        
        public override async Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourceListDto input)
        {
            var query = _repository.GetQueryableWithAuthorizationStatus(CurrentUser.GetId(), input.AuthorizedOnly)
                .Where(x => x.Resource.CategoryId == input.CategoryId);

            if (!await _categoryDataPermissionProvider.IsCurrentUserAllowedToManageAsync(input.CategoryId))
            {
                query = query.Where(x => x.Resource.IsPublished);
            }

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            
            query = query.PageBy(input);

            var resources = await AsyncQueryableExecuter.ToListAsync(query);

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
        
        public virtual async Task<PagedResultDto<ResourceDto>> GetListAuthorizedAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _repository.GetUserAuthorizedOnlyQueryable(CurrentUser.GetId()).Where(x => x.IsPublished);
            
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            var getResourceListDto = input as GetResourceListDto;

            query = ApplySorting(query, getResourceListDto);
            query = ApplyPaging(query, getResourceListDto);

            var resources = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<ResourceDto>(
                totalCount,
                resources.Select(MapToGetListOutputDto).ToList()
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
            
            MapToEntity(input, resource);
            
            await Repository.UpdateAsync(resource, autoSave: true);

            return MapToGetOutputDto(resource);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var resource = await GetEntityByIdAsync(id);
            
            await _categoryDataPermissionProvider.CheckCurrentUserAllowedToManageAsync(resource.CategoryId);

            await base.DeleteAsync(id);
        }

    }
}