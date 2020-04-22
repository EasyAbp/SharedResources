using System;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUserRepository : EfCoreRepository<SharedResourcesDbContext, ResourceUser, Guid>, IResourceUserRepository
    {
        public ResourceUserRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}