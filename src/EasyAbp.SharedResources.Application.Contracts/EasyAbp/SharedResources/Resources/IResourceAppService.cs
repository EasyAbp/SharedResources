using System;
using EasyAbp.SharedResources.Resources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.Resources
{
    public interface IResourceAppService :
        ICrudAppService< 
            ResourceDto, 
            Guid, 
            GetResourceListDto,
            CreateUpdateResourceDto,
            CreateUpdateResourceDto>
    {

    }
}