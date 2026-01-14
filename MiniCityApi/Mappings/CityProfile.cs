using AutoMapper;
using MiniCityApi.DomainModel;
using MiniCityApi.DTOs;
using MiniCityApi.Model;
using System.Runtime;


namespace MiniCityApi.Mappings
{
    public class CityProfile : Profile
    {

        public CityProfile()
        {
            CreateMap<CityModel, CityDto>();

            CreateMap<CreateCityDto, CityModel>();
            CreateMap<CityModel, CityDto>();

            CreateMap<UpdateCityDto, CityModel>();


        }

    }
}
