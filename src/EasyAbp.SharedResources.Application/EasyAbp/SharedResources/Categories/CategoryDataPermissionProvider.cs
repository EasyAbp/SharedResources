using System;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.CategoryOwners;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace EasyAbp.SharedResources.Categories
{
    public class CategoryDataPermissionProvider : ICategoryDataPermissionProvider, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICategoryOwnerRepository _categoryOwnerRepository;

        public CategoryDataPermissionProvider(
            ICurrentUser currentUser,
            IAuthorizationService authorizationService,
            ICategoryOwnerRepository categoryOwnerRepository)
        {
            _currentUser = currentUser;
            _authorizationService = authorizationService;
            _categoryOwnerRepository = categoryOwnerRepository;
        }
        
        public virtual async Task CheckCurrentUserAllowedToManageAsync(Guid categoryId)
        {
            if (!await IsCurrentUserAllowedToManageAsync(categoryId))
            {
                throw new AbpAuthorizationException();
            }
        }
        
        public virtual async Task<bool> IsCurrentUserAllowedToManageAsync(Guid categoryId)
        {
            return await IsCurrentUserHasGlobalManagePermissionAsync() || await IsCurrentUserOwnerAsync(categoryId);
        }

        public virtual async Task<bool> IsCommonCategoryAsync(Guid categoryId)
        {
            return await _categoryOwnerRepository.FindAsync(x => x.CategoryId == categoryId && x.OwnerUserId == null) != null;
        }
        
        public virtual async Task<bool> HasAnyCategoryOwnerAsync(Guid categoryId)
        {
            return await _categoryOwnerRepository.GetCountAsync(categoryId) != 0;
        }

        public virtual async Task<bool> IsCurrentUserOwnerAsync(Guid categoryId)
        {
            return await _categoryOwnerRepository.FindAsync(x =>
                x.CategoryId == categoryId && x.OwnerUserId == _currentUser.GetId()) != null;
        }
        
        public virtual async Task<bool> IsCurrentUserHasGlobalManagePermissionAsync()
        {
            return await _authorizationService.IsGrantedAsync(SharedResourcesPermissions.Categories.GlobalManage);
        }
    }
}