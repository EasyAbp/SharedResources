using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.ResourceItems
{
    public interface IResourceItemRepository : IRepository<ResourceItem, Guid>
    {
    }
}