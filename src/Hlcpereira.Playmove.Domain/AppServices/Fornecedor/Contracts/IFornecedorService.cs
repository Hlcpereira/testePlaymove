using System;
using System.Threading.Tasks;

using FornecedorEntity = Hlcpereira.Playmove.Domain.Entities.Fornecedor;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Commands;

namespace Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Contracts
{
    public interface IFornecedorService
    {
        public Task<FornecedorEntity> Create(CreateFornecedorCommand command);
        public Task<FornecedorEntity> Update(UpdateFornecedorCommand command, Guid id);
        public Task<FornecedorEntity> Delete(Guid id);
    }
}