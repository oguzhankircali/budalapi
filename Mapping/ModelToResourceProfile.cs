
using AutoMapper;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;

namespace Budalapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<Country, SaveCountryModel>();

            CreateMap<City, CityDto>();
            CreateMap<City, SaveCityModel>();

            CreateMap<District, DistrictDto>();
            CreateMap<District, SaveDistrictModel>();
        }
    }
}