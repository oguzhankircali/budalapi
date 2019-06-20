
using Budalapi.Persistence.Contexts;

namespace Budalapi.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BudalapiContext _context;
        public BaseRepository(BudalapiContext context)
        {
            _context = context;
        }
    }
}