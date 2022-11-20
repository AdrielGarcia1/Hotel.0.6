using ApplicationServices.Features.Rentals.Commands.CreateRentalCommand;
using ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand;
using ApplicationServices.Features.Rentals.Commands.UpdateRentalCommand;
using ApplicationServices.Features.Rentals.Queries.SelectAllQueries;
using ApplicationServices.Features.Rentals.Queries.SelectByQuery;
using ApplicationServices.filters.Rental;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class RentalSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] RentalResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectRentalQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCost = filter.TotalCost,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectRentalByQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRentalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateRentalCommand command)
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
            return Ok(await Mediator.Send(new DeleteRentalCommand { Id = id }));
        }
    }
}
