using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Categories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<IQueryable<Category>> GetQueryableAsync(Guid? ownerUserId);
    }
}