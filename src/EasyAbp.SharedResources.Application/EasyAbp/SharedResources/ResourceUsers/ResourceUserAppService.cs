using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;

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

        private readonly IResourceRepository _resourceRepository;
        private readonly IResourceUserRepository _repository;

        public ResourceUserAppService(
            IResourceRepository resourceRepository,
            IResourceUserRepository repository) : base(repository)
        {
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
            
            if (!await IsCurrentUserOwnerOrAdminAsync(dto.UserId))
            {
                throw new EntityNotFoundException(typeof(ResourceUser), id);
            }

            return dto;
        }

        public override async Task<PagedResultDto<ResourceUserDto>> GetListAsync(GetResourceUserListDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);
            
            if (!await IsCurrentUserOwnerOrAdminAsync(resource.OwnerUserId))
            {
                throw new EntityNotFoundException(typeof(Resource), input.ResourceId);
            }

            return await base.GetListAsync(input);
        }

        public override async Task<ResourceUserDto> CreateAsync(CreateUpdateResourceUserDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);
            
            await CheckCurrentUserAllowedToModifyAsync(resource.OwnerUserId);
            
            return await base.CreateAsync(input);
        }

        public override async Task<ResourceUserDto> UpdateAsync(Guid id, CreateUpdateResourceUserDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.ResourceId);

            await CheckCurrentUserAllowedToModifyAsync(resource.OwnerUserId);
            
            return await base.UpdateAsync(id, input);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var resourceUser = await GetEntityByIdAsync(id);
            
            var resource = await _resourceRepository.GetAsync(resourceUser.ResourceId);

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
                   await AuthorizationService.IsGrantedAsync(SharedResourcesPermissions.ResourceUsers.GlobalManage);
        }
    }
}