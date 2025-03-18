using Microsoft.EntityFrameworkCore;

namespace Hlcpereira.Playmove.Domain.Contracts.DataContext
{
    public interface IDataContext
    {
        DbContext DbContext { get; }
    }
}