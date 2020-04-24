using System;
using System.Linq;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryRepository : EfCoreRepository<SharedResourcesDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<Category> GetQueryable(Guid? ownerUserId)
        {
            return from category in DbContext.Categories
                join categoryOwner in DbContext.CategoryOwners on category.Id equals categoryOwner.CategoryId
                where categoryOwner.OwnerUserId == ownerUserId
                select category;
        }
    }
}