using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.Categories.Dtos
{
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid? ParentCategoryId { get; set; }

        public Guid? OwnerUserId { get; set; }

        public string Name { get; set; }
    }
}