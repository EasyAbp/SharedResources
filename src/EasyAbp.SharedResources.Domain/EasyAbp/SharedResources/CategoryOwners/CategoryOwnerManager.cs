using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public class CategoryOwnerManager : DomainService, ICategoryOwnerManager
    {
        private readonly ICategoryOwnerRepository _categoryOwnerRepository;

        public CategoryOwnerManager(ICategoryOwnerRepository categoryOwnerRepository)
        {
            _categoryOwnerRepository = categoryOwnerRepository;
        }

        public async Task<CategoryOwner> FindCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            return await _categoryOwnerRepository.FindAsync(x =>
                x.CategoryId == categoryId && x.OwnerUserId == ownerUserId);
        }

        public virtual async Task<CategoryOwner> GetOrAddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            return await FindCategoryOwnerAsync(categoryId, ownerUserId) ??
                   await AddCategoryOwnerAsync(categoryId, ownerUserId);
        }
        
        public virtual async Task RemoveCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            await _categoryOwnerRepository.DeleteAsync(x => x.CategoryId == categoryId && x.OwnerUserId == ownerUserId);
        }
        
        public virtual async Task RemoveAllCategoryOwnersAsync(Guid categoryId)
        {
            await _categoryOwnerRepository.DeleteAsync(x => x.CategoryId == categoryId);
        }


        public virtual async Task<CategoryOwner> AddCategoryOwnerAsync(Guid categoryId, Guid? ownerUserId)
        {
            return await _categoryOwnerRepository.InsertAsync(new CategoryOwner(GuidGenerator.Create(), CurrentTenant.Id,
                categoryId, ownerUserId));
        }
    }
}