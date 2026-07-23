using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser.ViewModels;
using Newtonsoft.Json;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.Mapperly;

namespace EasyAbp.SharedResources.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CategoryDtoToCreateEditCategoryViewModelMapper : MapperBase<CategoryDto, CreateEditCategoryViewModel>
    {
        [MapperIgnoreTarget(nameof(CreateEditCategoryViewModel.SetToCommon))]
        public override partial CreateEditCategoryViewModel Map(CategoryDto source);

        [MapperIgnoreTarget(nameof(CreateEditCategoryViewModel.SetToCommon))]
        public override partial void Map(CategoryDto source, CreateEditCategoryViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditCategoryViewModelToCreateUpdateCategoryDtoMapper : MapperBase<CreateEditCategoryViewModel, CreateUpdateCategoryDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdateCategoryDto.CustomMark))]
        public override partial CreateUpdateCategoryDto Map(CreateEditCategoryViewModel source);

        [MapperIgnoreTarget(nameof(CreateUpdateCategoryDto.CustomMark))]
        public override partial void Map(CreateEditCategoryViewModel source, CreateUpdateCategoryDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceDtoToCreateEditResourceViewModelMapper : MapperBase<ResourceDto, CreateEditResourceViewModel>
    {
        [MapperIgnoreTarget(nameof(CreateEditResourceViewModel.ExtraProperties))]
        public override partial CreateEditResourceViewModel Map(ResourceDto source);

        [MapperIgnoreTarget(nameof(CreateEditResourceViewModel.ExtraProperties))]
        public override partial void Map(ResourceDto source, CreateEditResourceViewModel destination);

        public override void AfterMap(ResourceDto source, CreateEditResourceViewModel destination)
        {
            destination.ExtraProperties = JsonConvert.SerializeObject(source.ExtraProperties);
        }
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditResourceViewModelToCreateUpdateResourceDtoMapper : MapperBase<CreateEditResourceViewModel, CreateUpdateResourceDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdateResourceDto.ExtraProperties))]
        public override partial CreateUpdateResourceDto Map(CreateEditResourceViewModel source);

        [MapperIgnoreTarget(nameof(CreateUpdateResourceDto.ExtraProperties))]
        public override partial void Map(CreateEditResourceViewModel source, CreateUpdateResourceDto destination);

        public override void AfterMap(CreateEditResourceViewModel source, CreateUpdateResourceDto destination)
        {
            destination.ExtraProperties.Clear();

            var extraProperties = JsonConvert.DeserializeObject<ExtraPropertyDictionary>(source.ExtraProperties);

            if (extraProperties != null)
            {
                foreach (var pair in extraProperties)
                {
                    destination.ExtraProperties[pair.Key] = pair.Value;
                }
            }
        }
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceItemDtoToCreateEditResourceItemViewModelMapper : MapperBase<ResourceItemDto, CreateEditResourceItemViewModel>
    {
        public override partial CreateEditResourceItemViewModel Map(ResourceItemDto source);

        public override partial void Map(ResourceItemDto source, CreateEditResourceItemViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditResourceItemViewModelToCreateUpdateResourceItemDtoMapper : MapperBase<CreateEditResourceItemViewModel, CreateUpdateResourceItemDto>
    {
        public override partial CreateUpdateResourceItemDto Map(CreateEditResourceItemViewModel source);

        public override partial void Map(CreateEditResourceItemViewModel source, CreateUpdateResourceItemDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceItemContentDtoToCreateEditResourceItemContentViewModelMapper : MapperBase<ResourceItemContentDto, CreateEditResourceItemContentViewModel>
    {
        public override partial CreateEditResourceItemContentViewModel Map(ResourceItemContentDto source);

        public override partial void Map(ResourceItemContentDto source, CreateEditResourceItemContentViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditResourceItemContentViewModelToCreateUpdateResourceItemContentDtoMapper : MapperBase<CreateEditResourceItemContentViewModel, CreateUpdateResourceItemContentDto>
    {
        public override partial CreateUpdateResourceItemContentDto Map(CreateEditResourceItemContentViewModel source);

        public override partial void Map(CreateEditResourceItemContentViewModel source, CreateUpdateResourceItemContentDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ResourceUserDtoToCreateEditResourceUserViewModelMapper : MapperBase<ResourceUserDto, CreateEditResourceUserViewModel>
    {
        public override partial CreateEditResourceUserViewModel Map(ResourceUserDto source);

        public override partial void Map(ResourceUserDto source, CreateEditResourceUserViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateEditResourceUserViewModelToCreateUpdateResourceUserDtoMapper : MapperBase<CreateEditResourceUserViewModel, CreateUpdateResourceUserDto>
    {
        public override partial CreateUpdateResourceUserDto Map(CreateEditResourceUserViewModel source);

        public override partial void Map(CreateEditResourceUserViewModel source, CreateUpdateResourceUserDto destination);
    }
}
