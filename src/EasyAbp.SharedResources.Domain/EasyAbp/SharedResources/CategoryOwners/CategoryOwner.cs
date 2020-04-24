using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public class CategoryOwner : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid CategoryId { get; protected set; }
        
        public virtual Guid? OwnerUserId { get; protected set; }

        protected CategoryOwner() {}
        
        public CategoryOwner(
            Guid id,
            Guid? tenantId,
            Guid categoryId,
            Guid? ownerUserId) : base(id)
        {
            TenantId = tenantId;
            CategoryId = categoryId;
            OwnerUserId = ownerUserId;
        }
    }
}