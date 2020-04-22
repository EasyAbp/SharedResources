using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUser : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid ResourceId { get; protected set; }
        
        public virtual Guid UserId { get; protected set; }
        
        protected ResourceUser()
        {
        }

        public ResourceUser(
            Guid id,
            Guid? tenantId,
            Guid resourceId,
            Guid userId
        ) :base(id)
        {
            TenantId = tenantId;
            ResourceId = resourceId;
            UserId = userId;
        }
    }
}
