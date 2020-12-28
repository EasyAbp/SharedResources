using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Data;

namespace EasyAbp.SharedResources.Resources.Dtos
{
    public class CreateUpdateResourceDto : IHasExtraProperties
    {
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }

        [DisplayName("ResourceName")]
        public string Name { get; set; }

        [DisplayName("ResourceDescription")]
        public string Description { get; set; }

        [DisplayName("ResourcePreviewMediaResources")]
        public string PreviewMediaResources { get; set; }

        [DisplayName("ResourceExtraProperties")]
        public ExtraPropertyDictionary ExtraProperties { get; set; }
        
        [DisplayName("ResourceIsPublished")]
        public bool IsPublished { get; set; }
    }
}