
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;

namespace Budalapi.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();

        Task AddAsync(City item);
        Task<City> FindByIdAsync(int id);
        void Update(City item);
    }
}