using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.ResourceUsers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.ResourceItems
{
    [Authorize]
    public class ResourceItemAppService : CrudAppService<ResourceItem, ResourceItemDto, Guid, GetResourceItemListDto, CreateUpdateResourceItemDto, CreateUpdateResourceItemDto>,
        IResourceItemAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Resources.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Update;

        private readonly IResourceItemContentConverter _resourceItemContentConverter;
        private readonly IResourceRepository _resourceRepository;
        private readonly IResourceUserRepository _resourceUserRepository;
        private readonly IResourceItemRepository _repository;

        public ResourceItemAppService(
            IResourceItemContentConverter resourceItemContentConverter,
            IResourceRepository resourceRepository,
            IResourceUserRepository resourceUserRepository,
            IResourceItemRepository repository) : base(repository)
        {
            _resourceItemContentConverter = resourceItemContentConverter;
            _resourceRepository = resourceRepository;
            _resourceUserRepository = resourceUserRepository;
            _repository = repository;
        }

        protected override IQueryable<ResourceItem> CreateFilteredQuery(GetResourceItemListDto input)
        {
            return base.CreateFilteredQuery(input).Where(x => x.ResourceId == input.ResourceId);
        }

        public override async Task<ResourceItemDto> GetAsync(Guid id)
        {
            var resourceItem = await GetEntityByIdAsync(id);
            
            var resource = await _resourceRepository.GetAsync(resourceItem.ResourceId);

            if ((!resourceItem.IsPublished || !resource.IsPublished) &&
                !await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                throw new EntityNotFoundException(typeof(ResourceItem), id);
            }

            var dto = await MapToGetOutputDtoAsync(resourceItem);

            if (resourceItem.IsPublic || await IsCurrentUserAuthorizedAsync(resource.Id))
            {
                return dto;
            }

            if (!await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                return RemoveResourceItemContent(dto);
            }

            return dto;
        }

        public override async Task<PagedResultDto<ResourceItemDto>> GetListAsync(GetResourceItemListDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);
            
            if (!resource.IsPublished && !await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                throw new EntityNotFoundException(typeof(Resource), input.ResourceId);
            }

            var query = CreateFilteredQuery(input);

            if (!await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                query = query.Where(x => x.IsPublished);
                
                if (!await IsCurrentUserAuthorizedAsync(resource.Id))
                {
                    query = query.Where(x => x.IsPublic);
                }
            }

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var resourceItems = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<ResourceItemDto>(
                totalCount,
                await MapToGetOutputDtoAsync(resourceItems)
            );
        }

        public override async Task<ResourceItemDto> CreateAsync(CreateUpdateResourceItemDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.ResourceId);

            return await base.CreateAsync(input);
        }

        public override async Task<ResourceItemDto> UpdateAsync(Guid id, CreateUpdateResourceItemDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.ResourceId);

            await CheckUpdatePolicyAsync();

            var resourceItem = await GetEntityByIdAsync(id);

            if (resourceItem.ResourceId != input.ResourceId)
            {
                await CheckCurrentUserAllowedToModifyAsync(resourceItem.ResourceId);
            }
            
            MapToEntity(input, resourceItem);
            
            await Repository.UpdateAsync(resourceItem, autoSave: true);

            return await MapToGetOutputDtoAsync(resourceItem);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var resourceItem = await GetEntityByIdAsync(id);
            
            await CheckCurrentUserAllowedToModifyAsync(resourceItem.ResourceId);

            await base.DeleteAsync(id);
        }

        protected virtual async Task CheckCurrentUserAllowedToModifyAsync(Guid resourceId)
        {
            var resource = await _resourceRepository.GetAsync(resourceId);

            if (!await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                throw new EntityNotFoundException(typeof(Resource), resource.Id);
            }
        }

        protected virtual async Task<ResourceItemDto> MapToGetOutputDtoAsync(ResourceItem resourceItem)
        {
            var dto = MapToGetOutputDto(resourceItem);

            if (dto.ResourceItemContent != null)
            {
                dto.ResourceItemContent.Content =
                    await _resourceItemContentConverter.GetConvertedContentAsync(dto.ResourceItemContent.Content);
            }

            return dto;
        }
        
        protected virtual async Task<List<ResourceItemDto>> MapToGetOutputDtoAsync(IEnumerable<ResourceItem> resourceItems)
        {
            var result = new List<ResourceItemDto>();
            
            foreach (var resourceItem in resourceItems)
            {
                result.Add(await MapToGetOutputDtoAsync(resourceItem));
            }

            return result;
        }

        protected virtual ResourceItemDto RemoveResourceItemContent(ResourceItemDto dto)
        {
            dto.ResourceItemContent = null;
            
            return dto;
        }

        protected virtual async Task<bool> IsCurrentUserAuthorizedAsync(Guid resourceId)
        {
            return CurrentUser.Id.HasValue &&
                   await _resourceUserRepository.FindAsync(resourceId, CurrentUser.Id.Value) != null;
        }
        
        protected virtual async Task<bool> IsCurrentUserOwnerOrAdminAsync(Guid? resourceOwnerUserId)
        {
            return CurrentUser.Id.HasValue && CurrentUser.Id.Value == resourceOwnerUserId ||
                   await AuthorizationService.IsGrantedAsync(SharedResourcesPermissions.Resources.GlobalManage);
        }
    }
}