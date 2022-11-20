using ApplicationServices.Features.Estates.Commands.CreateEstateCommand;
using ApplicationServices.Features.Estates.Commands.DeletEstateCommand;
using ApplicationServices.Features.Estates.Commands.UpdateEstateCommand;
using ApplicationServices.Features.Estates.Queries.SelectAllQueries;
using ApplicationServices.Features.Estates.Queries.SelectByQuery;
using ApplicationServices.filters.Estate;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class StateSystemControllers : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] EstateResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectEstateQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                NameEstate = filter.NameEstate,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectEstateByQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateEstateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateEstateCommand command)
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
            return Ok(await Mediator.Send(new DeletStateCommand { Id = id }));
        }
    }
}