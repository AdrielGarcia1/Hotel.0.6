using ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand;
using ApplicationServices.Features.UserReceps.Commands.DeleteUserRecepCommand;
using ApplicationServices.Features.UserReceps.Commands.UpdateUserRecepCommand;
using ApplicationServices.Features.UserReceps.Queries.SelectAllQueries;
using ApplicationServices.Features.UserReceps.Queries.SelectByQuery;
using ApplicationServices.filters.UserRecep;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class UserRecepSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserRecepResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectUserRecepQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameUser = filter.NameUser,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectUserRecepByQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRecepCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateUserRecepCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            }
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteUserRecepCommand { Id = id }));
        }
    }
}
