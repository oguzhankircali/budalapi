
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public interface ICityService
    {
        Task<City> GetAsync(int countryId);
        Task<IEnumerable<City>> ListAsync();
        Task<SaveCityResponse> SaveAsync(City category);
        Task<SaveCityResponse> UpdateAsync(int id, City category);
        Task<IEnumerable<City>> ListByCountryIdAsync(int countryId);
        Task<SaveCityResponse> DeleteAsync(int id);
    }
}