using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.SharedResources.MongoDB
{
    public static class SharedResourcesMongoDbContextExtensions
    {
        public static void ConfigureSharedResources(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SharedResourcesMongoModelBuilderConfigurationOptions(
                SharedResourcesDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}