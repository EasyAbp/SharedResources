using EasyAbp.SharedResources.Categories;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace EasyAbp.SharedResources
{
    public class SharedResourcesApplicationAutoMapperProfile : Profile
    {
        public SharedResourcesApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdateCategoryDto, Category>(MemberList.Source)
                .ForSourceMember(dto => dto.SetToCommon, opt => opt.DoNotValidate());
            CreateMap<Resource, ResourceDto>();
            CreateMap<CreateUpdateResourceDto, Resource>(MemberList.Source);
            CreateMap<ResourceItem, ResourceItemDto>();
            CreateMap<CreateUpdateResourceItemDto, ResourceItem>(MemberList.Source);
            CreateMap<ResourceUser, ResourceUserDto>();
            CreateMap<CreateUpdateResourceUserDto, ResourceUser>(MemberList.Source);
            CreateMap<ResourceItemContent, ResourceItemContentDto>();
            CreateMap<CreateUpdateResourceItemContentDto, ResourceItemContent>(MemberList.Source);
        }
    }
}
