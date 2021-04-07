using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.Resources
{
    public class ResourceRepository : EfCoreRepository<ISharedResourcesDbContext, Resource, Guid>, IResourceRepository
    {
        public ResourceRepository(IDbContextProvider<ISharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<IQueryable<Resource>> GetUserAuthorizedOnlyQueryableAsync(Guid userId)
        {
            return from resource in (await GetDbContextAsync()).Resources
                join resourceUser in (await GetDbContextAsync()).ResourceUsers on resource.Id equals resourceUser.ResourceId
                where resourceUser.UserId == userId
                select resource;
        }

        public virtual async Task<IQueryable<ResourceAuthorizationQueryModel>> GetQueryableWithAuthorizationStatusAsync(
            Guid? userId, bool getAuthorizedOnly)
        {
            if (getAuthorizedOnly)
            {
                if (!userId.HasValue)
                {
                    return (await GetQueryableAsync()).Where(x => false).Select(x => new ResourceAuthorizationQueryModel
                        {Resource = x, IsAuthorized = false});
                }

                return from resource in (await GetDbContextAsync()).Resources
                    join resourceUser in (await GetDbContextAsync()).ResourceUsers on
                        new
                        {
                            ResourceId = resource.Id,
                            UserId = userId.Value
                        }
                        equals new
                        {
                            ResourceId = resourceUser.ResourceId,
                            UserId = resourceUser.UserId
                        }
                    select new ResourceAuthorizationQueryModel {Resource = resource, IsAuthorized = true};
            }

            if (!userId.HasValue)
            {
                return (await GetQueryableAsync()).Select(x => new ResourceAuthorizationQueryModel
                    {Resource = x, IsAuthorized = false});
            }

            return from resource in (await GetDbContextAsync()).Resources
                join resourceUser in (await GetDbContextAsync()).ResourceUsers on
                    new
                    {
                        ResourceId = resource.Id,
                        UserId = userId.Value
                    }
                    equals new
                    {
                        ResourceId = resourceUser.ResourceId,
                        UserId = resourceUser.UserId
                    } into resourceUsers
                from ru in resourceUsers.DefaultIfEmpty()
                select new ResourceAuthorizationQueryModel {Resource = resource, IsAuthorized = ru != null};
        }
    }
}