using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.SharedResources.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
