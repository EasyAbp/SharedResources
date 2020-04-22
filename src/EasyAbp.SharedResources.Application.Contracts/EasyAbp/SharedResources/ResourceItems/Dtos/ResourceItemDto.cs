using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceItems.Dtos
{
    public class ResourceItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResourceId { get; set; }

        public ResourceItemType ResourceItemType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public bool IsPublic { get; set; }
        
        public ResourceItemContentDto ResourceItemContent { get; set; }
    }
}