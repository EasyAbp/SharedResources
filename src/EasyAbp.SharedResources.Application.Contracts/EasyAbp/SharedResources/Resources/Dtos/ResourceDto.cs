using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class ResourceDto : FullAuditedEntityDto<Guid>
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PreviewMediaResources { get; set; }

        public bool IsPublished { get; set; }
        
        public bool? IsAuthorized { get; set; }
    }
}