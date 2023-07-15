using ApplicationServices.Features.Estates.Commands.CreateEstateCommand;
using ApplicationServices.Features.Estates.Commands.DeletEstateCommand;
using ApplicationServices.Features.Estates.Commands.UpdateEstateCommand;
using ApplicationServices.Features.Estates.Queries.SelectAllQueries;
using ApplicationServices.Features.Estates.Queries.SelectByQuery;
using ApplicationServices.filters.Estate;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de estados
    [ApiVersion("1.0")]
    public class StateSystemControllers : BaseApiController
    {
        // GET: /api/v1.0/StateSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] EstateResponseFilter filter)
        {
            // Obtiene todos los estados utilizando la consulta SelectEstateQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectEstateQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameEstate = filter.NameEstate,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/StateSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un estado por su ID utilizando la consulta SelectEstateByQuery
            return Ok(await Mediator.Send(new SelectEstateByQuery { Id = id }));
        }

        // POST: /api/v1.0/StateSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateEstateCommand command)
        {
            // Crea un nuevo estado utilizando el comando CreateEstateCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/StateSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateEstateCommand command)
        {
            // Actualiza un estado existente utilizando el comando UpdateEstateCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/StateSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un estado por su ID utilizando el comando DeletStateCommand
            return Ok(await Mediator.Send(new DeletStateCommand { Id = id }));
        }
    }
}
