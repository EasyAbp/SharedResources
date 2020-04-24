using System;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Categories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        IQueryable<Category> GetQueryable(Guid? ownerUserId);
    }
}