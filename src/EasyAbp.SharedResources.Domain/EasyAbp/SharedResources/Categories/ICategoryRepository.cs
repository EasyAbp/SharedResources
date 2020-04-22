using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Categories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}