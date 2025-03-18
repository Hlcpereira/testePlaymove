/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hlcpereira.Playmove.Data.Extensions;

using FornecedorEntity = Hlcpereira.Playmove.Domain.Entities.Fornecedor;

namespace Hlcpereira.Playmove.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorEntity>
    {
        private const string TABLE_NAME = "fornecedor";
        public void Configure(EntityTypeBuilder<FornecedorEntity> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.MapId(x => x.Id);
            builder.MapVarchar(x => x.Name, "name", false);
            builder.MapVarchar(x => x.Email, "email", false);

            builder.OwnsOne(a => a.Address, a =>
                {
                    a.MapVarchar(a => a.Street, "street", 100, true);
                    a.MapVarchar(a => a.Number, "number", 50, false);
                    a.MapVarchar(a => a.Complement, "complement", 100, false);
                    a.MapVarchar(a => a.Neighborhood, "neighborhood", 100, true);
                    a.MapVarchar(a => a.ZipCode, "zip_code", 50, true);
                })
                .Navigation(a => a.Address)
                .IsRequired();
        }        
    }
}