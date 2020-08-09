using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public class ResourceUserRepository : EfCoreRepository<ISharedResourcesDbContext, ResourceUser, Guid>, IResourceUserRepository
    {
        public ResourceUserRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<ResourceUser> FindAsync(Guid resourceId, Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetQueryable().Where(x => x.UserId == userId && x.ResourceId == resourceId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<List<ResourceUser>> GetListByResourceIdAsync(Guid resourceId, CancellationToken cancellationToken = default)
        {
            return await GetQueryable().Where(x => x.ResourceId == resourceId).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<ResourceUser>> GetListByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await GetQueryable().Where(x => x.UserId == userId).ToListAsync(cancellationToken);

        }
    }
}