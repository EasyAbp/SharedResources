using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    public class SharedResourcesModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SharedResourcesModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}