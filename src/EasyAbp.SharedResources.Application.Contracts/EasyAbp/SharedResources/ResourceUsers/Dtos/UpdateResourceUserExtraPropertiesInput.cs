using System;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class UpdateResourceUserExtraPropertiesInput : ExtensibleObject
    {
        public Guid ResourceId { get; set; }
        
        /// <summary>
        /// Use the current user ID if this property is null.
        /// </summary>
        public Guid? UserId { get; set; }
    }
}