
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public interface ICountryService
    {
        Task<Country> GetAsync(int countryId);
        Task<IEnumerable<Country>> ListAsync();
        Task<SaveCountryResponse> SaveAsync(Country item);
        Task<SaveCountryResponse> UpdateAsync(int id, Country item);
        Task DeleteAsync(int id);
    }
}