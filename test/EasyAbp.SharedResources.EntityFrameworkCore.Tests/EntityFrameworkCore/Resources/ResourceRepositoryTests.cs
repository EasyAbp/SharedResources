using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Resources;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.SharedResources.EntityFrameworkCore.Resources
{
    public class ResourceRepositoryTests : SharedResourcesEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Resource, Guid> _resourceRepository;

        public ResourceRepositoryTests()
        {
            _resourceRepository = GetRequiredService<IRepository<Resource, Guid>>();
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
