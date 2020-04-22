using System;
using System.Linq;
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

        public IQueryable<Resource> GetUserAuthorizedOnlyQueryable(Guid userId)
        {
            return from resource in DbContext.Resources
                join resourceUser in DbContext.ResourceUsers on resource.Id equals resourceUser.ResourceId
                where resourceUser.UserId == userId
                select resource;
        }
    }
}