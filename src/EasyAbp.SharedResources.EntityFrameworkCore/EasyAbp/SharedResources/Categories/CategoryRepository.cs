using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryRepository : EfCoreRepository<ISharedResourcesDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<ISharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<IQueryable<Category>> GetQueryableAsync(Guid? ownerUserId)
        {
            return from category in (await GetDbContextAsync()).Categories
                join categoryOwner in (await GetDbContextAsync()).CategoryOwners on category.Id equals categoryOwner.CategoryId
                where categoryOwner.OwnerUserId == ownerUserId
                select category;
        }
    }
}