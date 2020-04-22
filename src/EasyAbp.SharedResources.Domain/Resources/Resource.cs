using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.Resources
{
    public class Resource : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid? CategoryId { get; protected set; }
        
        public virtual Guid? OwnerUserId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        [CanBeNull]
        public virtual string PreviewMediaResources { get; protected set; }
        
        public virtual bool IsPublished { get; protected set; }
    }
}