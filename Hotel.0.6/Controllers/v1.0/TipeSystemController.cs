using ApplicationServices.Features.Tipes.Commands.CreateTipeCommand;
using ApplicationServices.Features.Tipes.Commands.DeleteTipeCommand;
using ApplicationServices.Features.Tipes.Commands.UpdateTipeCommand;
using ApplicationServices.Features.Tipes.Queries.SelectAllQueries;
using ApplicationServices.Features.Tipes.Queries.SelectByQuery;
using ApplicationServices.filters.Types;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de tipos de habitaciones
    [ApiVersion("1.0")]
    public class TipeSystemController : BaseApiController
    {
        // GET: /api/v1.0/TipeSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] TipeResponseFilter filter)
        {
            // Obtiene todos los tipos de habitaciones utilizando la consulta SelectTipeQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectTipeQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameRoom = filter.NameRoom,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/TipeSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un tipo de habitación por su ID utilizando la consulta SelectTipeByQuery
            return Ok(await Mediator.Send(new SelectTipeByQuery { Id = id }));
        }

        // POST: /api/v1.0/TipeSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateTipeCommand command)
        {
            // Crea un nuevo tipo de habitación utilizando el comando CreateTipeCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/TipeSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateTipeCommand command)
        {
            // Actualiza un tipo de habitación existente utilizando el comando UpdateTipeCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/TipeSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un tipo de habitación por su ID utilizando el comando DeleteTipeCommand
            return Ok(await Mediator.Send(new DeleteTipeCommand { Id = id }));
        }
    }
}