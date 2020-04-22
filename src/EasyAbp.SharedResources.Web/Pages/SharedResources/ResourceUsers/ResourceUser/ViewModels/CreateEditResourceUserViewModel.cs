using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser.ViewModels
{
    public class CreateEditResourceUserViewModel
    {
        [HiddenInput]
        [Display(Name = "Resource")]
        public Guid ResourceId { get; set; }

        [Display(Name = "ResourceUserUserId")]
        public Guid UserId { get; set; }
    }
}