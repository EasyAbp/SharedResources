using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUserAppServiceTests : SharedResourcesApplicationTestBase
    {
        private readonly IResourceUserAppService _resourceUserAppService;

        public ResourceUserAppServiceTests()
        {
            _resourceUserAppService = GetRequiredService<IResourceUserAppService>();
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
