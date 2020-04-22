using System;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public interface IResourceUserAppService :
        ICrudAppService< 
            ResourceUserDto, 
            Guid, 
            GetResourceUserListDto,
            CreateUpdateResourceUserDto,
            CreateUpdateResourceUserDto>
    {

    }
}