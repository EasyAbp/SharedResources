using System;
using System.Linq;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Resources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceAppService : CrudAppService<Resource, ResourceDto, Guid, GetResourceListDto, CreateUpdateResourceDto, CreateUpdateResourceDto>,
        IResourceAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Resources.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Update;
        protected override string GetPolicyName { get; set; } = SharedResourcesPermissions.Resources.Default;
        protected override string GetListPolicyName { get; set; } = SharedResourcesPermissions.Resources.Default;
        
        private readonly IResourceRepository _repository;

        public ResourceAppService(IResourceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<Resource> CreateFilteredQuery(GetResourceListDto input)
        {
            return base.CreateFilteredQuery(input)
                .Where(x => x.CategoryId == input.CategoryId && x.OwnerUserId == input.OwnerUserId);
        }
    }
}