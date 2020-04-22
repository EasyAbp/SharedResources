using System;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.ResourceItems
{
    public interface IResourceItemAppService :
        ICrudAppService< 
            ResourceItemDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateResourceItemDto,
            CreateUpdateResourceItemDto>
    {

    }
}