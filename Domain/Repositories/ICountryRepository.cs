
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budalapi.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
    }
}