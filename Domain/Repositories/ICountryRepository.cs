
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;

namespace Budalapi.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();

        Task AddAsync(Country item);
        Task<Country> FindByIdAsync(int id);
        void Update(Country item);
        Task Delete(int id);
    }
}