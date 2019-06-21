
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
            CreateMap<Country, SaveCountryDto>();

            CreateMap<City, CityDto>();
            CreateMap<District, DistrictDto>();
        }
    }
}