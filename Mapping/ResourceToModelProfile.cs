
using AutoMapper;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;

namespace Budalapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CountryResource, Country>();
        }
    }
}