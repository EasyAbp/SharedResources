using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Categories.Dtos
{
    public class GetCategoryListDto : PagedAndSortedResultRequestDto
    {
        public Guid? OwnerUserId { get; set; }

        public Guid? RootCategoryId { get; set; }
    }
}