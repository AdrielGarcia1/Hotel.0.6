using ApplicationServices.Features.Clients.Commands.CreateClientCommand;
using ApplicationServices.Features.Clients.Commands.DeletClientCommand;
using ApplicationServices.Features.Clients.Commands.UpdateClientCommand;
using ApplicationServices.Features.Clients.Queries.SelectAllQueries;
using ApplicationServices.Features.Clients.Queries.SelectByQuery;
using ApplicationServices.filters.ClientsF;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de clientes
    [ApiVersion("1.0")]
    public class ClientSystemController : BaseApiController
    {
        // GET: /api/v1.0/ClientSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] ClientResponseFilter filter)
        {
            // Obtiene todos los clientes utilizando la consulta SelectClientQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectClientQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameClient = filter.NameClient,
                LastNameClient = filter.LastNameClient,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/ClientSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un cliente por su ID utilizando la consulta SelectClientByQuery
            return Ok(await Mediator.Send(new SelectClientByQuery { Id = id }));
        }

        // POST: /api/v1.0/ClientSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            // Crea un nuevo cliente utilizando el comando CreateClientCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/ClientSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateClientCommand command)
        {
            // Actualiza un cliente existente utilizando el comando UpdateClientCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/ClientSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un cliente por su ID utilizando el comando DeletClientCommand
            return Ok(await Mediator.Send(new DeletClientCommand { Id = id }));
        }
    }
}