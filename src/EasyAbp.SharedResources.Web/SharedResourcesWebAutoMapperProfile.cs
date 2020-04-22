using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using AutoMapper;

namespace EasyAbp.SharedResources.Web
{
    public class SharedResourcesWebAutoMapperProfile : Profile
    {
        public SharedResourcesWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CategoryDto, CreateUpdateCategoryDto>();
            CreateMap<ResourceDto, CreateUpdateResourceDto>();
            CreateMap<ResourceItemDto, CreateUpdateResourceItemDto>();
            CreateMap<ResourceUserDto, CreateUpdateResourceUserDto>();
        }
    }
}
