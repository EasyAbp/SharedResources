using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Categories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    [DependsOn(
        typeof(SharedResourcesDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class SharedResourcesEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SharedResourcesDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Category, CategoryRepository>();
                options.AddRepository<Resource, ResourceRepository>();
                options.AddRepository<ResourceItem, ResourceItemRepository>();
                options.AddRepository<ResourceUser, ResourceUserRepository>();
            });
        }
    }
}
