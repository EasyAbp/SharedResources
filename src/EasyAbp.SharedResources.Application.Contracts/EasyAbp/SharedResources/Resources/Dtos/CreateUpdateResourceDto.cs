using System;
using System.ComponentModel;
namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class CreateUpdateResourceDto
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