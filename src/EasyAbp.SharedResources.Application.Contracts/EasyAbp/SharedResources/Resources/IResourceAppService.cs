using System;
using System.Threading.Tasks;
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
        Task<PagedResultDto<ResourceDto>> GetListAuthorizedAsync(PagedAndSortedResultRequestDto input);
    }
}