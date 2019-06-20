using System.Threading.Tasks;
using Budalapi.Persistence.Contexts;

namespace Budalapi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudalapiContext _context;

        public UnitOfWork(BudalapiContext context)
        {
            _context = context;
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}