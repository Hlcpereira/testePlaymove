using Hlcpereira.Playmove.Domain.DataTransferObjects;

namespace Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Commands
{
    public class CreateFornecedorCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public AddressDTO Address { get; set; }
    }
}