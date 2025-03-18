using Hlcpereira.Playmove.Domain.Contracts.DataContext;
using Hlcpereira.Playmove.Domain.Contracts.Repositories;
using Hlcpereira.Playmove.Domain.Entities;

namespace Hlcpereira.Playmove.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IDataContext dataContext) : base(dataContext) {}
    }
}