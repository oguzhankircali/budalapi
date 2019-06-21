
using System.Collections.Generic;
using System.Threading.Tasks;
using Budalapi.Domain.Models;
using Budalapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Budalapi.Repositories
{
    public class DistrictRepository : BaseRepository, IDistrictRepository
    {
        public DistrictRepository(BudalapiContext context) : base(context)
        {

        }
        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _context.District.ToListAsync();
        }

        public async Task AddAsync(District item)
        {
            await _context.District.AddAsync(item);
        }

        public async Task<District> FindByIdAsync(int id)
        {
            return await _context.District.FindAsync(id);
        }

        public void Update(District item)
        {
            _context.District.Update(item);
        }
    }
}