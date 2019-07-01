
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
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

        public async Task AddAsync(Country item)
        {
            await _context.Country.AddAsync(item);
        }

        public async Task<Country> FindByIdAsync(int id)
        {
            return await _context.Country.FindAsync(id);
        }

        public void Update(Country item)
        {
            _context.Country.Update(item);
        }

        public async Task Delete(int id)
        {
            var item = await _context.Country.FindAsync(id);
            _context.Country.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}