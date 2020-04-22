using System;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceRepository : EfCoreRepository<SharedResourcesDbContext, Resource, Guid>, IResourceRepository
    {
        public ResourceRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}