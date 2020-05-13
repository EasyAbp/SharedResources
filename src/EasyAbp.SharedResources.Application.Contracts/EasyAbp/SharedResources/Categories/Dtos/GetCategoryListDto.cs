using System;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Categories.Dtos
{
    public class GetCategoryListDto : PagedAndSortedResultRequestDto
    {
        public Guid? OwnerUserId { get; set; }

        public Guid? RootCategoryId { get; set; }
        
        [CanBeNull]
        public string CustomMark { get; set; }
    }
}