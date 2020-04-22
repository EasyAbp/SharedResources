using System;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemAppService : CrudAppService<ResourceItem, ResourceItemDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateResourceItemDto, CreateUpdateResourceItemDto>,
        IResourceItemAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Resources.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Resources.Update;
        protected override string GetPolicyName { get; set; } = SharedResourcesPermissions.Resources.Default;
        protected override string GetListPolicyName { get; set; } = SharedResourcesPermissions.Resources.Default;
        
        private readonly IResourceItemRepository _repository;

        public ResourceItemAppService(IResourceItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}