using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Resources
{
    public interface IResourceRepository : IRepository<Resource, Guid>
    {
    }
}