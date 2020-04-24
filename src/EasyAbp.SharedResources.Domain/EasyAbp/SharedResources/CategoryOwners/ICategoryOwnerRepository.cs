using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public interface ICategoryOwnerRepository : IRepository<CategoryOwner, Guid>
    {
    }
}