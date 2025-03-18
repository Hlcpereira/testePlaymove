using System;

using Hlcpereira.Playmove.Domain.ValueObjects;

namespace Hlcpereira.Playmove.Domain.Entities
{
    public class Fornecedor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }
    }
}