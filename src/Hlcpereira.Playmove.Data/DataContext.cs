using Microsoft.EntityFrameworkCore;
using System.Reflection;

using Hlcpereira.Playmove.Data.Map;
using Hlcpereira.Playmove.Domain.Contracts.DataContext;

namespace Hlcpereira.Playmove.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public const string Schema = "public";

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbContext = this;
        }

        public DbContext DbContext { get; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema(Schema);

            mb.ApplyConfigurationsFromAssembly(typeof(FornecedorMap).GetTypeInfo().Assembly);
        } 
    }
}