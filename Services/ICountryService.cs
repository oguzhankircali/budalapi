
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budalapi.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
    }
}