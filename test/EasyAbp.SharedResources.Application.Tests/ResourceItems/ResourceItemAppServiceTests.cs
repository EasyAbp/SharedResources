using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemAppServiceTests : SharedResourcesApplicationTestBase
    {
        private readonly IResourceItemAppService _resourceItemAppService;

        public ResourceItemAppServiceTests()
        {
            _resourceItemAppService = GetRequiredService<IResourceItemAppService>();
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
