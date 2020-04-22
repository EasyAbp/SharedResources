using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.ResourceItems;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.SharedResources.EntityFrameworkCore.ResourceItems
{
    public class ResourceItemRepositoryTests : SharedResourcesEntityFrameworkCoreTestBase
    {
        private readonly IRepository<ResourceItem, Guid> _resourceItemRepository;

        public ResourceItemRepositoryTests()
        {
            _resourceItemRepository = GetRequiredService<IRepository<ResourceItem, Guid>>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
