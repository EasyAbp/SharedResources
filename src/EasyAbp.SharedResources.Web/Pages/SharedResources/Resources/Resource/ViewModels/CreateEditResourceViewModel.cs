using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels
{
    public class CreateEditResourceViewModel
    {
        [HiddenInput]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }

        [Display(Name = "ResourceName")]
        public string Name { get; set; }

        [Display(Name = "ResourceDescription")]
        public string Description { get; set; }

        [Display(Name = "ResourcePreviewMediaResources")]
        public string PreviewMediaResources { get; set; }

        [TextArea(Rows = 4)]
        [Display(Name = "ResourceExtraProperties")]
        public string ExtraProperties { get; set; }
        
        [Display(Name = "ResourceIsPublished")]
        public bool IsPublished { get; set; }
    }
}