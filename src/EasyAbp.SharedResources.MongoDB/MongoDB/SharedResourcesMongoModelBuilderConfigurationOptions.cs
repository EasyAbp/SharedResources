using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.SharedResources.MongoDB
{
    public class SharedResourcesMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public SharedResourcesMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}