using System;
using Volo.Abp.Data;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    [Serializable]
    public class GetResourceUserExtraPropertiesInputOutput : IHasExtraProperties
    {
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}