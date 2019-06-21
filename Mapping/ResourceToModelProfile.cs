
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
            CreateMap<SaveCountryDto, Country>();

            CreateMap<CityDto, City>();
            CreateMap<DistrictDto, District>();
        }
    }
}