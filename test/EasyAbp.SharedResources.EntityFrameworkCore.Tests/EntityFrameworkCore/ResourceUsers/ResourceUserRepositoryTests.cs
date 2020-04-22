using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.ResourceUsers;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.SharedResources.EntityFrameworkCore.ResourceUsers
{
    public class ResourceUserRepositoryTests : SharedResourcesEntityFrameworkCoreTestBase
    {
        private readonly IRepository<ResourceUser, Guid> _resourceUserRepository;

        public ResourceUserRepositoryTests()
        {
            _resourceUserRepository = GetRequiredService<IRepository<ResourceUser, Guid>>();
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
