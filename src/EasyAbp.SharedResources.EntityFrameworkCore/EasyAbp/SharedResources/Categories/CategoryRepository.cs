using System;
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
    }
}