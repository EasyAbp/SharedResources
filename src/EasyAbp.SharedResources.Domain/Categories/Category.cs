using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid? ParentCategoryId { get; protected set; }
        
        public virtual Guid? OwnerUserId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }
    }
}