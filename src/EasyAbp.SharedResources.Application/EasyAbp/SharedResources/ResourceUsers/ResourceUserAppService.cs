using System;
using System.Linq;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
        
        private readonly IResourceUserRepository _repository;

        public ResourceUserAppService(IResourceUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
        
        protected override IQueryable<ResourceUser> CreateFilteredQuery(GetResourceUserListDto input)
        {
            return base.CreateFilteredQuery(input).Where(x => x.ResourceId == input.ResourceId);
        }
    }
}