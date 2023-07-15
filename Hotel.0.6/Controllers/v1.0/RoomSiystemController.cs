using ApplicationServices.Features.Rooms.Commands.CreateRoomCommand;
using ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand;
using ApplicationServices.Features.Rooms.Commands.UpdateRoomCommand;
using ApplicationServices.Features.Rooms.Queries.SelectAllQueries;
using ApplicationServices.Features.Rooms.Queries.SelectByQuery;
using ApplicationServices.filters.Room;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de habitaciones
    [ApiVersion("1.0")]
    public class RoomSiystemController : BaseApiController
    {
        // GET: /api/v1.0/RoomSiystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] RoomResponseFilter filter)
        {
            // Obtiene todas las habitaciones utilizando la consulta SelectRoomQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectRoomQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NumberRoom = filter.NumberRoom,
                Cost = filter.Cost,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/RoomSiystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene una habitación por su ID utilizando la consulta SelectRoomByQuery
            return Ok(await Mediator.Send(new SelectRoomByQuery { Id = id }));
        }

        // POST: /api/v1.0/RoomSiystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateRoomCommand command)
        {
            // Crea una nueva habitación utilizando el comando CreateRoomCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/RoomSiystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRoomCommand command)
        {
            // Actualiza una habitación existente utilizando el comando UpdateRoomCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/RoomSiystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina una habitación por su ID utilizando el comando DeleteRoomCommand
            return Ok(await Mediator.Send(new DeleteRoomCommand { Id = id }));
        }
    }
}