using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
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

        private readonly IResourceUserRepository _resourceUserRepository;
        private readonly IResourceRepository _repository;

        public ResourceAppService(
            IResourceUserRepository resourceUserRepository,
            IResourceRepository repository) : base(repository)
        {
            _resourceUserRepository = resourceUserRepository;
            _repository = repository;
        }

        protected override IQueryable<Resource> CreateFilteredQuery(GetResourceListDto input)
        {
            var query = input.AuthorizedOnly ? _repository.GetUserAuthorizedOnlyQueryable(CurrentUser.GetId()) : _repository;

            return query.Where(x => x.CategoryId == input.CategoryId && x.OwnerUserId == input.OwnerUserId);
        }
        
        public override async Task<ResourceDto> GetAsync(Guid id)
        {
            var resource = await GetEntityByIdAsync(id);
            
            if (!resource.IsPublished && !await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                throw new EntityNotFoundException(typeof(Resource), id);
            }

            return MapToGetOutputDto(resource);
        }
        
        public override async Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourceListDto input)
        {
            var query = CreateFilteredQuery(input);

            if (!await IsCurrentUserOwnerOrAdminAsync(input.OwnerUserId))
            {
                query = query.Where(x => x.IsPublished);
            }

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var resources = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<ResourceDto>(
                totalCount,
                resources.Select(MapToGetListOutputDto).ToList()
            );
        }

        public override async Task<ResourceDto> CreateAsync(CreateUpdateResourceDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.OwnerUserId);
            
            return await base.CreateAsync(input);
        }
        
        public override async Task<ResourceDto> UpdateAsync(Guid id, CreateUpdateResourceDto input)
        {
            await CheckCurrentUserAllowedToModifyAsync(input.OwnerUserId);

            await CheckUpdatePolicyAsync();

            var resource = await GetEntityByIdAsync(id);

            if (resource.OwnerUserId != input.OwnerUserId)
            {
                await CheckCurrentUserAllowedToModifyAsync(resource.OwnerUserId);
            }
            
            MapToEntity(input, resource);
            
            await Repository.UpdateAsync(resource, autoSave: true);

            return MapToGetOutputDto(resource);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var resource = await GetEntityByIdAsync(id);
            
            await CheckCurrentUserAllowedToModifyAsync(resource.OwnerUserId);

            await base.DeleteAsync(id);
        }

        protected virtual async Task CheckCurrentUserAllowedToModifyAsync(Guid? resourceOwnerUserId)
        {
            if (!await IsCurrentUserOwnerOrAdminAsync(resourceOwnerUserId))
            {
                throw new AbpAuthorizationException();
            }
        }
        
        protected virtual async Task<bool> IsCurrentUserOwnerOrAdminAsync(Guid? resourceOwnerUserId)
        {
            return CurrentUser.Id.HasValue && CurrentUser.Id.Value == resourceOwnerUserId ||
                   await AuthorizationService.IsGrantedAsync(SharedResourcesPermissions.Resources.GlobalManage);
        }
    }
}