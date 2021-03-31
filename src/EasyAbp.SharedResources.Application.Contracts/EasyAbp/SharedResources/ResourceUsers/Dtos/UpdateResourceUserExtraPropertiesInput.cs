using Volo.Abp.Data;

namespace EasyAbp.SharedResources.ResourceUsers.Dtos
{
    public class UpdateResourceUserExtraPropertiesInput : IHasExtraProperties
    {
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}