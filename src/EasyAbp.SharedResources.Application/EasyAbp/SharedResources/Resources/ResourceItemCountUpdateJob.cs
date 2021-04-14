using System.Threading.Tasks;
using EasyAbp.SharedResources.ResourceItems;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceItemCountUpdateJob : IAsyncBackgroundJob<ResourceItemCountUpdateJobArgs>, ITransientDependency
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IResourceItemRepository _resourceItemRepository;

        public ResourceItemCountUpdateJob(
            IResourceRepository resourceRepository,
            IResourceItemRepository resourceItemRepository)
        {
            _resourceRepository = resourceRepository;
            _resourceItemRepository = resourceItemRepository;
        }
        
        [UnitOfWork]
        public virtual async Task ExecuteAsync(ResourceItemCountUpdateJobArgs args)
        {
            var resource = await _resourceRepository.FindAsync(args.ResourceId);

            if (resource == null)
            {
                return;
            }

            var count = await _resourceItemRepository.CountAsync(x => x.ResourceId == args.ResourceId && x.IsPublished);

            resource.SetItemCount(count);

            await _resourceRepository.UpdateAsync(resource, true);
        }
    }
}