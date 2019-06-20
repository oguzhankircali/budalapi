
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Budalapi.Repositories
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(BudalapiContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _context.Country.ToListAsync();
        }
    }
}