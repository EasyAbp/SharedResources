using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.SharedResources.Resources
{
    public class Resource : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid CategoryId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        [CanBeNull]
        public virtual string PreviewMediaResources { get; protected set; }
        
        public virtual bool IsPublished { get; protected set; }

        protected Resource()
        {
        }

        public Resource(
            Guid id,
            Guid categoryId,
            string name,
            string description,
            string previewMediaResources,
            bool isPublished
        ) :base(id)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            PreviewMediaResources = previewMediaResources;
            IsPublished = isPublished;
        }
    }
}
