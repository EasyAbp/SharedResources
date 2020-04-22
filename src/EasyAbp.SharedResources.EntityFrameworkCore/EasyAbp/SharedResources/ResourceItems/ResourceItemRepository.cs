using System;
using System.Linq;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemRepository : EfCoreRepository<SharedResourcesDbContext, ResourceItem, Guid>, IResourceItemRepository
    {
        public ResourceItemRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override IQueryable<ResourceItem> WithDetails()
        {
            return base.WithDetails().Include(x => x.ResourceItemContent);
        }
    }
}