using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceItems
{
    [RemoteService(Name = "EasyAbpSharedResources")]
    [Route("/api/shared-resources/resource-item")]
    public class ResourceItemController : SharedResourcesController, IResourceItemAppService
    {
        private readonly IResourceItemAppService _service;

        public ResourceItemController(IResourceItemAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ResourceItemDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ResourceItemDto>> GetListAsync(GetResourceItemListDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<ResourceItemDto> CreateAsync(CreateUpdateResourceItemDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ResourceItemDto> UpdateAsync(Guid id, CreateUpdateResourceItemDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}