using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class GetResourceListDto : PagedAndSortedResultRequestDto
    {
        public Guid CategoryId { get; set; }
        
        public bool AuthorizedOnly { get; set; }
    }
}