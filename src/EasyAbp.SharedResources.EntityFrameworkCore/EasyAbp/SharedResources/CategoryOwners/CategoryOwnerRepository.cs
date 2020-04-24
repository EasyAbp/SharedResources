using System;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public class CategoryOwnerRepository : EfCoreRepository<SharedResourcesDbContext, CategoryOwner, Guid>, ICategoryOwnerRepository
    {
        public CategoryOwnerRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}