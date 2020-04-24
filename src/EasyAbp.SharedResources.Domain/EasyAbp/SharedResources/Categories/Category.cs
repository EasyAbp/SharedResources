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

        protected Category()
        {
        }

        public Category(
            Guid id,
            Guid? parentCategoryId,
            string name
        ) :base(id)
        {
            ParentCategoryId = parentCategoryId;
            Name = name;
        }
    }
}
