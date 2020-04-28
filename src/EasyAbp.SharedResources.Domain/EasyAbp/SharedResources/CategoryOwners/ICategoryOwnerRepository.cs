using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public interface ICategoryOwnerRepository : IRepository<CategoryOwner, Guid>
    {
        Task<long> GetCountAsync(Guid categoryId, CancellationToken cancellationToken = default);
    }
}