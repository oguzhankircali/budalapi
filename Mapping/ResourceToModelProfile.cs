
using AutoMapper;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;

namespace Budalapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CountryDto, Country>();
            CreateMap<SaveCountryModel, Country>();

            CreateMap<CityDto, City>();
            CreateMap<SaveCityModel, City>();

            CreateMap<DistrictDto, District>();
            CreateMap<SaveDistrictModel, District>();
        }
    }
}