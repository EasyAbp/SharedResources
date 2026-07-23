using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.SharedResources
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CategoryToCategoryDtoMapper : MapperBase<Category, CategoryDto>
    {
        public override partial CategoryDto Map(Category source);

        public override partial void Map(Category source, CategoryDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceToResourceDtoMapper : MapperBase<Resource, ResourceDto>
    {
        [MapperIgnoreTarget(nameof(ResourceDto.IsAuthorized))]
        public override partial ResourceDto Map(Resource source);

        [MapperIgnoreTarget(nameof(ResourceDto.IsAuthorized))]
        public override partial void Map(Resource source, ResourceDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceItemToResourceItemDtoMapper : MapperBase<ResourceItem, ResourceItemDto>
    {
        public override partial ResourceItemDto Map(ResourceItem source);

        public override partial void Map(ResourceItem source, ResourceItemDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceItemContentToResourceItemContentDtoMapper : MapperBase<ResourceItemContent, ResourceItemContentDto>
    {
        public override partial ResourceItemContentDto Map(ResourceItemContent source);

        public override partial void Map(ResourceItemContent source, ResourceItemContentDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceUserToResourceUserDtoMapper : MapperBase<ResourceUser, ResourceUserDto>
    {
        public override partial ResourceUserDto Map(ResourceUser source);

        public override partial void Map(ResourceUser source, ResourceUserDto destination);
    }
}
