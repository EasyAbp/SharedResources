using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceItems.Dtos
{
    public class GetResourceItemListDto : PagedAndSortedResultRequestDto
    {
        public Guid ResourceId { get; set; }
    }
}