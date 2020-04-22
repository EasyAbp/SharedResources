using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceItems.Dtos
{
    public class ResourceItemContentDto : FullAuditedEntityDto
    {
        public string Content { get; set; }
    }
}