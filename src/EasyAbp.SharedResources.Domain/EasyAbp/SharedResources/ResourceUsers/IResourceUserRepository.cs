using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.ResourceUsers
{
    public interface IResourceUserRepository : IRepository<ResourceUser, Guid>
    {
    }
}