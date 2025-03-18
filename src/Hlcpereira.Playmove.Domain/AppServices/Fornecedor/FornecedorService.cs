using System;
using System.Threading.Tasks;

using FornecedorEntity = Hlcpereira.Playmove.Domain.Entities.Fornecedor;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Commands;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Contracts;
using Hlcpereira.Playmove.Domain.Contracts.Persistance;
using Hlcpereira.Playmove.Domain.Contracts.Repositories;
using Hlcpereira.Playmove.Domain.ValueObjects;

namespace Hlcpereira.Playmove.Domain.AppServices.Fornecedor
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        protected IFornecedorRepository _repository;

        public FornecedorService (
            IUnitOfWork uow,
            IFornecedorRepository repository
        ) : base(uow)
        {
            _repository = repository;
        }

        public async Task<FornecedorEntity> Create(CreateFornecedorCommand command)
        {
            var fornecedor = new FornecedorEntity()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Address = new Address()
                {
                    Street = command.Address.Street,
                    Number = command.Address.Number,
                    Complement = command.Address.Complement,
                    Neighborhood = command.Address.Neighborhood,
                    ZipCode = command.Address.ZipCode
                }
            };

            await _repository.AddAsync(fornecedor);
            await CommitAsync();

            return fornecedor;
        }

        public async Task<FornecedorEntity> Update(UpdateFornecedorCommand command, Guid id)
        {
            var fornecedor = await _repository.FindAsync(x => x.Id == id);

            fornecedor.Name = command.Name;
            fornecedor.Email = command.Email;
            fornecedor.Address.Street = command.Address.Street;
            fornecedor.Address.Number = command.Address.Number;
            fornecedor.Address.Complement = command.Address.Complement;
            fornecedor.Address.Neighborhood = command.Address.Neighborhood;
            fornecedor.Address.ZipCode = command.Address.ZipCode;

            _repository.Modify(fornecedor);
            await CommitAsync();

            return fornecedor;
        }

        public async Task<FornecedorEntity> Delete(Guid id)
        {
            var fornecedor = await _repository.FindAsync(x => x.Id == id);
    
            if(fornecedor == null)
                throw new Exception("Fornecedor não existe");

            _repository.Remove(fornecedor);

            await CommitAsync();

            return fornecedor;
        }
    }
}