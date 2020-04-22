using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class GetResourceUserListDto : PagedAndSortedResultRequestDto
    {
        public Guid ResourceId { get; set; }
    }
}