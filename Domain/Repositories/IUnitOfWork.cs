
using System.Threading.Tasks;

namespace Budalapi.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}