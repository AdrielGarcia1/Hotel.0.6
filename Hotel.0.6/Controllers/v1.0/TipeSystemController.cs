using ApplicationServices.Features.Tipes.Commands.CreateTipeCommand;
using ApplicationServices.Features.Tipes.Commands.DeleteTipeCommand;
using ApplicationServices.Features.Tipes.Commands.UpdateTipeCommand;
using ApplicationServices.Features.Tipes.Queries.SelectAllQueries;
using ApplicationServices.Features.Tipes.Queries.SelectByQuery;
using ApplicationServices.filters.Tipe;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class TipeSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] TipeResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectTipeQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameRoom = filter.NameRoom,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectTipeByQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateTipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateTipeCommand command)
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
            return Ok(await Mediator.Send(new DeleteTipeCommand { Id = id }));
        }
    }
}
