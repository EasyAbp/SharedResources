using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class ResourceUserDto : CreationAuditedEntityDto<Guid>
    {
        public Guid ResourceId { get; set; }

        public Guid UserId { get; set; }
    }
}