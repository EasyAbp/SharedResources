using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemContent : FullAuditedEntity
    {
        public virtual Guid ResourceItemId { get; protected set; }
        
        [NotNull]
        public virtual string Content { get; protected set; }
        
        public override object[] GetKeys()
        {
            return new object[] {ResourceItemId};
        }

        protected ResourceItemContent()
        {
        }

        public ResourceItemContent(
            Guid resourceItemId,
            string content
        )
        {
            ResourceItemId = resourceItemId;
            Content = content;
        }
    }
}
