using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUser : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid ResourceId { get; protected set; }
        
        public virtual Guid UserId { get; protected set; }
    }
}