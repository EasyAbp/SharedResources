using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.CategoryOwners;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.SharedResources.EntityFrameworkCore.CategoryOwners
{
    public class CategoryOwnerRepositoryTests : SharedResourcesEntityFrameworkCoreTestBase
    {
        private readonly IRepository<CategoryOwner, Guid> _categoryOwnerRepository;

        public CategoryOwnerRepositoryTests()
        {
            _categoryOwnerRepository = GetRequiredService<IRepository<CategoryOwner, Guid>>();
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
