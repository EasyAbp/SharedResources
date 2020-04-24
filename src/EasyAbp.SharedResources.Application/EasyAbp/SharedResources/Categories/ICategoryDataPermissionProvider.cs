using System;
using System.Threading.Tasks;

namespace EasyAbp.SharedResources.Categories
{
    public interface ICategoryDataPermissionProvider
    {
        Task CheckCurrentUserAllowedToManageAsync(Guid categoryId);

        Task<bool> IsCurrentUserAllowedToManageAsync(Guid categoryId);

        Task<bool> IsCommonCategoryAsync(Guid categoryId);

        Task<bool> IsCurrentUserOwnerAsync(Guid categoryId);

        Task<bool> IsCurrentUserHasGlobalManagePermissionAsync();
    }
}