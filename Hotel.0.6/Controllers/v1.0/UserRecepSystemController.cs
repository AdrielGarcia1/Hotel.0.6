using ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand;
using ApplicationServices.Features.UserReceps.Commands.DeleteUserRecepCommand;
using ApplicationServices.Features.UserReceps.Commands.UpdateUserRecepCommand;
using ApplicationServices.Features.UserReceps.Queries.SelectAllQueries;
using ApplicationServices.Features.UserReceps.Queries.SelectByQuery;
using ApplicationServices.filters.UserRecep;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de usuarios de recepción
    [ApiVersion("1.0")]
    public class UserRecepSystemController : BaseApiController
    {
        // GET: /api/v1.0/UserRecepSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserRecepResponseFilter filter)
        {
            // Obtiene todos los usuarios de recepción utilizando la consulta SelectUserRecepQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectUserRecepQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameUser = filter.NameUser,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/UserRecepSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un usuario de recepción por su ID utilizando la consulta SelectUserRecepByQuery
            return Ok(await Mediator.Send(new SelectUserRecepByQuery { Id = id }));
        }

        // POST: /api/v1.0/UserRecepSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRecepCommand command)
        {
            // Crea un nuevo usuario de recepción utilizando el comando CreateUserRecepCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/UserRecepSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateUserRecepCommand command)
        {
            // Actualiza un usuario de recepción existente utilizando el comando UpdateUserRecepCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/UserRecepSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un usuario de recepción por su ID utilizando el comando DeleteUserRecepCommand
            return Ok(await Mediator.Send(new DeleteUserRecepCommand { Id = id }));
        }
    }
}