using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.SharedResources.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid? ParentCategoryId { get; protected set; }
        
        [NotNull]
        public virtual string Name { get; protected set; }
        
        [CanBeNull]
        public virtual string CustomMark { get; protected set; }

        protected Category()
        {
        }

        public Category(
            Guid id,
            Guid? parentCategoryId,
            [NotNull] string name,
            [CanBeNull] string customMark
        ) :base(id)
        {
            ParentCategoryId = parentCategoryId;
            Name = name;
            CustomMark = customMark;
        }
    }
}
