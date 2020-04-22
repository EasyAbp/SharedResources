using System;
using System.ComponentModel;
namespace EasyAbp.SharedResources.ResourceItems.Dtos
{
    public class CreateUpdateResourceItemDto
    {
        [DisplayName("Resource")]
        public Guid ResourceId { get; set; }

        [DisplayName("ResourceItemName")]
        public string Name { get; set; }

        [DisplayName("ResourceItemDescription")]
        public string Description { get; set; }

        [DisplayName("ResourceItemIsPublished")]
        public bool IsPublished { get; set; }

        [DisplayName("ResourceItemIsPublic")]
        public bool IsPublic { get; set; }
    }
}