using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.SharedResources.Resources
{
    public interface IResourceRepository : IRepository<Resource, Guid>
    {
        Task<IQueryable<Resource>> GetUserAuthorizedOnlyQueryableAsync(Guid userId);
        
        Task<IQueryable<ResourceAuthorizationQueryModel>> GetQueryableWithAuthorizationStatusAsync(Guid? userId,
            bool getAuthorizedOnly);
    }
}