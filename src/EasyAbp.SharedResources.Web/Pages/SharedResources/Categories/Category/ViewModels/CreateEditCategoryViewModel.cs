using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category.ViewModels
{
    public class CreateEditCategoryViewModel
    {
        [HiddenInput]
        [Display(Name = "CategoryParentCategoryId")]
        public Guid? ParentCategoryId { get; set; }

        [Display(Name = "CategoryName")]
        public string Name { get; set; }
    }
}