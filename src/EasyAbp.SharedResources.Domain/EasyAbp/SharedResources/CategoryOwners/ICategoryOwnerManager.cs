using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public interface ICategoryOwnerManager : IDomainService
    {
        Task<CategoryOwner> FindCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId);
        
        Task<CategoryOwner> GetOrAddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId);

        Task RemoveCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId);

        Task RemoveAllCategoryOwnersAsync(Guid categoryId);

        Task<CategoryOwner> AddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId);
    }
}