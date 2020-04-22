using System;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.ResourceItems
{
    public class ResourceItemRepository : EfCoreRepository<SharedResourcesDbContext, ResourceItem, Guid>, IResourceItemRepository
    {
        public ResourceItemRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}