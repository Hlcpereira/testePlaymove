using System;
using System.Threading.Tasks;

using Hlcpereira.Playmove.Domain.Contracts.Persistance;

namespace Hlcpereira.Playmove.Domain.AppServices
{
    public class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task<bool> CommitAsync(bool throwIfFails = true)
        {
            if (await _uow.SaveChangesAsync() > 0) return true;

            if (throwIfFails)
                throw new Exception("Ops, não foi possível processar sua requisição no momento. Por favor tente novamente mais tarde");

            return false;
        }
    }
}