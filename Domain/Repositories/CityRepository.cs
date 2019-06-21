
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Budalapi.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(BudalapiContext context) : base(context)
        {

        }
        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task AddAsync(City item)
        {
            await _context.City.AddAsync(item);
        }

        public async Task<City> FindByIdAsync(int id)
        {
            return await _context.City.FindAsync(id);
        }

        public void Update(City item)
        {
            _context.City.Update(item);
        }
    }
}