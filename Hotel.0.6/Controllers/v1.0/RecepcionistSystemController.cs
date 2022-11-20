using ApplicationServices.Features.Recepcionists.Commands.CreateRecepcionistCommands;
using ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand;
using ApplicationServices.Features.Recepcionists.Commands.UpdateRecepcionistCommand;
using ApplicationServices.Features.Recepcionists.Queries.SelectAllQueries;
using ApplicationServices.Features.Recepcionists.Queries.SelectByQuery;
using ApplicationServices.filters.Receptionist;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion ("1.0")]
    public class RecepcionistSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] ReceptionistResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectReceptionistQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameRecep = filter.NameRecep,
                LastNameRecep = filter.LastNameRecep,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectReceptionistByQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecepcionistCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRecepcionistCommand command)
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
            return Ok(await Mediator.Send(new DeleteReceptionistCommand { Id = id }));
        }
    }
}
