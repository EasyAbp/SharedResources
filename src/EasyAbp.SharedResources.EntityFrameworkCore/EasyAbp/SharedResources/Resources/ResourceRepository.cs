using System;
using System.Linq;
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

        public virtual IQueryable<Resource> GetUserAuthorizedOnlyQueryable(Guid userId)
        {
            return from resource in DbContext.Resources
                join resourceUser in DbContext.ResourceUsers on resource.Id equals resourceUser.ResourceId
                where resourceUser.UserId == userId
                select resource;
        }
        
        public virtual IQueryable<ResourceAuthorizationQueryModel> GetQueryableWithAuthorizationStatus(Guid userId,
            bool getAuthorizedOnly)
        {
            if (getAuthorizedOnly)
            {
                return from resource in DbContext.Resources
                    join resourceUser in DbContext.ResourceUsers on
                        new
                        {
                            ResourceId = resource.Id,
                            UserId = userId
                        }
                        equals new
                        {
                            ResourceId = resourceUser.ResourceId,
                            UserId = resourceUser.UserId
                        }
                    select new ResourceAuthorizationQueryModel {Resource = resource, IsAuthorized = true};
            }

            return from resource in DbContext.Resources
                join resourceUser in DbContext.ResourceUsers on
                    new
                    {
                        ResourceId = resource.Id,
                        UserId = userId
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