using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public interface IResourceUserRepository : IRepository<ResourceUser, Guid>
    {
        Task<ResourceUser> FindAsync(Guid resourceId, Guid userId, CancellationToken cancellationToken = default);

        Task<List<ResourceUser>> GetListByResourceIdAsync(Guid resourceId, CancellationToken cancellationToken = default);
        
        Task<List<ResourceUser>> GetListByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}