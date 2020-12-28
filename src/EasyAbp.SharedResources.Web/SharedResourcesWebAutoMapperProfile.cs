using System.Collections.Generic;
using EasyAbp.SharedResources.Categories.Dtos;
using EasyAbp.SharedResources.Resources.Dtos;
using EasyAbp.SharedResources.ResourceItems.Dtos;
using EasyAbp.SharedResources.ResourceUsers.Dtos;
using AutoMapper;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Categories.Category.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceItems.ResourceItem.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.Resources.Resource.ViewModels;
using EasyAbp.SharedResources.Web.Pages.SharedResources.ResourceUsers.ResourceUser.ViewModels;
using Newtonsoft.Json;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;

namespace EasyAbp.SharedResources.Web
{
    public class SharedResourcesWebAutoMapperProfile : Profile
    {
        public SharedResourcesWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CategoryDto, CreateEditCategoryViewModel>()
                .Ignore(model => model.SetToCommon);
            CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>()
                .Ignore(dto => dto.CustomMark);
            CreateMap<ResourceDto, CreateEditResourceViewModel>()
                .ForSourceMember(dto => dto.IsAuthorized, opt => opt.DoNotValidate())
                .ForMember(model => model.ExtraProperties, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExtraProperties)));
            CreateMap<CreateEditResourceViewModel, CreateUpdateResourceDto>()
                .ForMember(dto => dto.ExtraProperties,
                    opt => opt.MapFrom(src =>
                        JsonConvert.DeserializeObject<ExtraPropertyDictionary>(src.ExtraProperties)));
            CreateMap<ResourceItemDto, CreateEditResourceItemViewModel>();
            CreateMap<CreateEditResourceItemViewModel, CreateUpdateResourceItemDto>();
            CreateMap<ResourceItemContentDto, CreateEditResourceItemContentViewModel>();
            CreateMap<CreateEditResourceItemContentViewModel, CreateUpdateResourceItemContentDto>();
            CreateMap<ResourceUserDto, CreateEditResourceUserViewModel>();
            CreateMap<CreateEditResourceUserViewModel, CreateUpdateResourceUserDto>();
        }
    }
}
