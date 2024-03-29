using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Categories
{
    [RemoteService(Name = SharedResourcesRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/shared-resources/category")]
    public class CategoryController : SharedResourcesController, ICategoryAppService
    {
        private readonly ICategoryAppService _service;

        public CategoryController(ICategoryAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CategoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
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