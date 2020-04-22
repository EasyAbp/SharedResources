using System;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        protected override string CreatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Create;
        protected override string DeletePolicyName { get; set; } = SharedResourcesPermissions.Categories.Delete;
        protected override string UpdatePolicyName { get; set; } = SharedResourcesPermissions.Categories.Update;
        protected override string GetPolicyName { get; set; } = SharedResourcesPermissions.Categories.Default;
        protected override string GetListPolicyName { get; set; } = SharedResourcesPermissions.Categories.Default;
        
        private readonly ICategoryRepository _repository;

        public CategoryAppService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}