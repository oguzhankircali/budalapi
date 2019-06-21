
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public interface ICountryService
    {
        Task<CountryResource> GetAsync(int countryId);
        Task<IEnumerable<Country>> ListAsync();
        Task<SaveCountryResponse> SaveAsync(Country category);
        Task<SaveCountryResponse> UpdateAsync(int id, Country category);
    }
}