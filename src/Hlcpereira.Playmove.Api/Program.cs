using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Hlcpereira.Playmove.Api.Config;
using Hlcpereira.Playmove.Data;
using Hlcpereira.Playmove.Data.Repositories;
using Hlcpereira.Playmove.Domain.Contracts.Persistance;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Contracts;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor;
using Hlcpereira.Playmove.Domain.Contracts.Persistance;
using Hlcpereira.Playmove.Domain.Contracts.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;
var enviroment = builder.Environment;

// Start of DI
services.AddScoped<IFornecedorService, FornecedorService>();
services.AddScoped<IFornecedorRepository, FornecedorRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("playmove", new OpenApiInfo { Title = "General playmove", Version = "v1" });
    }
);

services.AppAddDatabase(configuration, enviroment);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/playmove/swagger.json", "Hlcpereira.Playmove.Api v1");
}
);

app.UseHttpsRedirection();

app.UseAuthorization();
app.AppEnsureMigrations(enviroment);

app.MapControllers();

app.Run();
