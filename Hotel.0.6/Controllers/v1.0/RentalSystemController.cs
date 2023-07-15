using ApplicationServices.Features.Rentals.Commands.CreateRentalCommand;
using ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand;
using ApplicationServices.Features.Rentals.Commands.UpdateRentalCommand;
using ApplicationServices.Features.Rentals.Queries.SelectAllQueries;
using ApplicationServices.Features.Rentals.Queries.SelectByQuery;
using ApplicationServices.filters.Rental;
using Microsoft.AspNetCore.Mvc;
namespace Hotel_Web_Api.Controllers.v1._0
{
    // Controlador de la API para el sistema de alquileres
    [ApiVersion("1.0")]
    public class RentalSystemController : BaseApiController
    {
        // GET: /api/v1.0/RentalSystem
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] RentalResponseFilter filter)
        {
            // Obtiene todos los alquileres utilizando la consulta SelectRentalQuery
            // con los parámetros de filtro proporcionados
            return Ok(await Mediator.Send(new SelectRentalQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCost = filter.TotalCost,
                IsDeleted = filter.IsDeleted
            }));
        }

        // GET: /api/v1.0/RentalSystem/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            // Obtiene un alquiler por su ID utilizando la consulta SelectRentalByQuery
            return Ok(await Mediator.Send(new SelectRentalByQuery { Id = id }));
        }

        // POST: /api/v1.0/RentalSystem
        [HttpPost]
        public async Task<IActionResult> Post(CreateRentalCommand command)
        {
            // Crea un nuevo alquiler utilizando el comando CreateRentalCommand
            return Ok(await Mediator.Send(command));
        }

        // PUT: /api/v1.0/RentalSystem/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRentalCommand command)
        {
            // Actualiza un alquiler existente utilizando el comando UpdateRentalCommand
            // Se verifica que el ID proporcionado coincida con el ID en el comando
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE: /api/v1.0/RentalSystem/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            // Elimina un alquiler por su ID utilizando el comando DeleteRentalCommand
            return Ok(await Mediator.Send(new DeleteRentalCommand { Id = id }));
        }
    }
}