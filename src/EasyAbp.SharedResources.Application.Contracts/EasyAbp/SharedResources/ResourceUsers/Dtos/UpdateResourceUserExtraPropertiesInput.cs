using System;
using Volo.Abp.Data;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class UpdateResourceUserExtraPropertiesInput : IHasExtraProperties
    {
        public Guid ResourceId { get; set; }
        
        /// <summary>
        /// Use the current user ID if this property is null.
        /// </summary>
        public Guid? UserId { get; set; }
        
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}