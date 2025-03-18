using System.Threading.Tasks;

namespace Hlcpereira.Playmove.Domain.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}