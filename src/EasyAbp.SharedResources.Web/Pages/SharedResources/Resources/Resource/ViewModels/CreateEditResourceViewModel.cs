using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels
{
    public class CreateEditResourceViewModel
    {
        [HiddenInput]
        [Display(Name = "Category")]
        public Guid? CategoryId { get; set; }

        [HiddenInput]
        [Display(Name = "ResourceOwnerUserId")]
        public Guid? OwnerUserId { get; set; }

        [Display(Name = "ResourceName")]
        public string Name { get; set; }

        [Display(Name = "ResourceDescription")]
        public string Description { get; set; }

        [Display(Name = "ResourcePreviewMediaResources")]
        public string PreviewMediaResources { get; set; }

        [Display(Name = "ResourceIsPublished")]
        public bool IsPublished { get; set; }
    }
}