using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItem : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid ResourceId { get; protected set; }
        
        public virtual ResourceItemType ResourceItemType { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        public virtual bool IsPublished { get; protected set; }
        
        public virtual bool IsPublic { get; protected set; }
        
        public virtual ResourceItemContent ResourceItemContent { get; protected set; }

        protected ResourceItem()
        {
        }

        public ResourceItem(
            Guid id,
            Guid resourceId,
            ResourceItemType resourceItemType,
            string name,
            string description,
            bool isPublished,
            bool isPublic
        ) :base(id)
        {
            ResourceId = resourceId;
            ResourceItemType = resourceItemType;
            Name = name;
            Description = description;
            IsPublished = isPublished;
            IsPublic = isPublic;
        }
    }
}
