
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Domain.Resources;
using Budalapi.Services.Communication;

namespace Budalapi.Services
{
    public interface IDistrictService
    {
        Task<District> GetAsync(int countryId);
        Task<IEnumerable<District>> ListAsync();
        Task<SaveDistrictResponse> SaveAsync(District category);
        Task<SaveDistrictResponse> UpdateAsync(int id, District category);
    }
}