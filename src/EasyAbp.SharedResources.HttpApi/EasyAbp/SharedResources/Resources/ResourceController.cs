using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Resources.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Resources
{
    [RemoteService(Name = "EasyAbpSharedResources")]
    [Route("/api/sharedResources/resource")]
    public class ResourceController : SharedResourcesController, IResourceAppService
    {
        private readonly IResourceAppService _service;

        public ResourceController(IResourceAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ResourceDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourceListDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<ResourceDto> CreateAsync(CreateUpdateResourceDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ResourceDto> UpdateAsync(Guid id, CreateUpdateResourceDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("authorized")]
        public Task<PagedResultDto<ResourceDto>> GetListAuthorizedAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAuthorizedAsync(input);
        }
    }
}