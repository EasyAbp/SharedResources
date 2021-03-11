using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemRepository : EfCoreRepository<ISharedResourcesDbContext, ResourceItem, Guid>, IResourceItemRepository
    {
        public ResourceItemRepository(IDbContextProvider<ISharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<ResourceItem>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync()).Include(x => x.ResourceItemContent);
        }
    }
}