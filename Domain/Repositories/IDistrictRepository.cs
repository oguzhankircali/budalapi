
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;

namespace Budalapi.Repositories
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> ListAsync();

        Task AddAsync(District item);
        Task<District> FindByIdAsync(int id);
        void Update(District item);
    }
}