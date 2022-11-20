using ApplicationServices.Features.Clients.Commands.CreateClientCommand;
using ApplicationServices.Features.Clients.Commands.DeletClientCommand;
using ApplicationServices.Features.Clients.Commands.UpdateClientCommand;
using ApplicationServices.Features.Clients.Queries.SelectAllQueries;
using ApplicationServices.Features.Clients.Queries.SelectByQuery;
using ApplicationServices.filters.ClientsF;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class ClientSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] ClientResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectClientQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameClient = filter.NameClient,
                LastNameClient = filter.LastNameClient,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectClientByQuery { Id = id }));
        }
        [HttpPost]//Crea Clientes Nuevos
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]// Modifica/Actualiza los datos
        public async Task<IActionResult> Put(long id, UpdateClientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeletClientCommand { Id = id }));
        }
    }
}
