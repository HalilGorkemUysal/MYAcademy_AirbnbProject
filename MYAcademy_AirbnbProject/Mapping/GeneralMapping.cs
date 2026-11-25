using AutoMapper;
using MYAcademy_AirbnbProject.Dtos.CategoryDtos;
using MYAcademy_AirbnbProject.Dtos.HouseDtos;
using MYAcademy_AirbnbProject.Entities;

namespace MYAcademy_AirbnbProject.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
            CreateMap<GetByIdCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<ResultHouseDto, House>().ReverseMap();
            CreateMap<GetByIdHouseDto, House>().ReverseMap();
            CreateMap<CreateHouseDto, House>();
            CreateMap<UpdateHouseDto, House>();
        }
    }
}
