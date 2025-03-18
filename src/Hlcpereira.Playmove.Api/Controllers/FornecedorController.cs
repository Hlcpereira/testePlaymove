using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Contracts;
using Hlcpereira.Playmove.Domain.AppServices.Fornecedor.Commands;
using Hlcpereira.Playmove.Domain.Contracts.Repositories;

namespace Hlcpereira.Playmove.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
	{
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(
            [FromBody] CreateFornecedorCommand command,
            [FromServices] IFornecedorService service
        )
        {
            return Ok(await service.Create(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromServices] IFornecedorRepository repository
        )
        {
            return Ok(repository.ListAsNoTracking());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            [FromServices] IFornecedorRepository repository
        )
        {
            return Ok(await repository.FindAsNoTrackingAsync(x => x.Id == id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateFornecedorCommand command,
            [FromServices] IFornecedorService service
        )
        {
            return Ok(await service.Update(command, id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IFornecedorService service
        )
        {
            return Ok(await service.Delete(id));
        }
    }
}
