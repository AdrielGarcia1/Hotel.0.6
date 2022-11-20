using ApplicationServices.Features.Rooms.Commands.CreateRoomCommand;
using ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand;
using ApplicationServices.Features.Rooms.Commands.UpdateRoomCommand;
using ApplicationServices.Features.Rooms.Queries.SelectAllQueries;
using ApplicationServices.Features.Rooms.Queries.SelectByQuery;
using ApplicationServices.filters.Room;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class RoomSiystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] RoomResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectRoomQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NumberRoom = filter.NumberRoom,
                Cost = filter.Cost,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectRoomByQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateRoomCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRoomCommand command)
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
            return Ok(await Mediator.Send(new DeleteRoomCommand { Id = id }));
        }
    }
}
