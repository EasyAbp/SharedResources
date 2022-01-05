using System;
using System.ComponentModel;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class CreateUpdateResourceDto : ExtensibleObject
    {
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }

        [DisplayName("ResourceName")]
        public string Name { get; set; }

        [DisplayName("ResourceDescription")]
        public string Description { get; set; }

        [DisplayName("ResourcePreviewMediaResources")]
        public string PreviewMediaResources { get; set; }

        [DisplayName("ResourceIsPublished")]
        public bool IsPublished { get; set; }
    }
}