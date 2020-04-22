using System;
using System.Linq;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Resources
{
    public interface IResourceRepository : IRepository<Resource, Guid>
    {
        IQueryable<Resource> GetUserAuthorizedOnlyQueryable(Guid userId);
    }
}