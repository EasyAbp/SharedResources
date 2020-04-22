using System;
using System.ComponentModel;
namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class CreateUpdateResourceUserDto
    {
        [DisplayName("Resource")]
        public Guid ResourceId { get; set; }

        [DisplayName("ResourceUserUserId")]
        public Guid UserId { get; set; }
    }
}