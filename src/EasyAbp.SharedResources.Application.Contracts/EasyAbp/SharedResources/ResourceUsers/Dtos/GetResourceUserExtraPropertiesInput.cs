using System;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    [Serializable]
    public class GetResourceUserExtraPropertiesInput
    {
        public Guid ResourceId { get; set; }
        
        /// <summary>
        /// Use the current user ID if this property is null.
        /// </summary>
        public Guid? UserId { get; set; }
    }
}