using ApplicationServices.Features.Recepcionists.Commands.CreateRecepcionistCommands;
using ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand;
using ApplicationServices.Features.Recepcionists.Commands.UpdateRecepcionistCommand;
using ApplicationServices.Features.Recepcionists.Queries.SelectAllQueries;
using ApplicationServices.Features.Recepcionists.Queries.SelectByQuery;
using ApplicationServices.filters.Receptionist;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de recepcionistas
    [ApiVersion("1.0")]
    public class RecepcionistSystemController : BaseApiController
    {
        // GET: /api/v1.0/RecepcionistSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] ReceptionistResponseFilter filter)
        {
            // Obtiene todos los recepcionistas utilizando la consulta SelectReceptionistQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectReceptionistQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameRecep = filter.NameRecep,
                LastNameRecep = filter.LastNameRecep,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/RecepcionistSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un recepcionista por su ID utilizando la consulta SelectReceptionistByQuery
            return Ok(await Mediator.Send(new SelectReceptionistByQuery { Id = id }));
        }

        // POST: /api/v1.0/RecepcionistSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecepcionistCommand command)
        {
            // Crea un nuevo recepcionista utilizando el comando CreateRecepcionistCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/RecepcionistSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRecepcionistCommand command)
        {
            // Actualiza un recepcionista existente utilizando el comando UpdateRecepcionistCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/RecepcionistSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un recepcionista por su ID utilizando el comando DeleteReceptionistCommand
            return Ok(await Mediator.Send(new DeleteReceptionistCommand { Id = id }));
        }
    }
}