using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem.ViewModels
{
    public class CreateEditResourceItemContentViewModel
    {
        [TextArea(Rows = 4)]
        [Display(Name = "ResourceItemContentContent")]
        public string Content { get; set; }
    }
}