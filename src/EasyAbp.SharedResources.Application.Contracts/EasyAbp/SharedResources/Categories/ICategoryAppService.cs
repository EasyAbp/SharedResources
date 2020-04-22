using System;
using EasyAbp.SharedResources.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.Categories
{
    public interface ICategoryAppService :
        ICrudAppService< 
            CategoryDto, 
            Guid, 
            GetCategoryListDto,
            CreateUpdateCategoryDto,
            CreateUpdateCategoryDto>
    {

    }
}