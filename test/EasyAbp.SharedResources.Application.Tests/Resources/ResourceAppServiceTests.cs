using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceAppServiceTests : SharedResourcesApplicationTestBase
    {
        private readonly IResourceAppService _resourceAppService;

        public ResourceAppServiceTests()
        {
            _resourceAppService = GetRequiredService<IResourceAppService>();
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
