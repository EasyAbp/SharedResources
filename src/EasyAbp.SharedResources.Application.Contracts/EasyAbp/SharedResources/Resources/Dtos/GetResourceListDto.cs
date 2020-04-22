using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class GetResourceListDto : PagedAndSortedResultRequestDto
    {
        public Guid? OwnerUserId { get; set; }
        
        public Guid? CategoryId { get; set; }
    }
}