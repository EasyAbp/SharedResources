using System;
using System.ComponentModel;
namespace EasyAbp.SharedResources.ResourceItems.Dtos
{
    public class CreateUpdateResourceItemContentDto
    {
        [DisplayName("ResourceItemContentContent")]
        public string Content { get; set; }
    }
}