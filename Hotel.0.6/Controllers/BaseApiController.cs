using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel_Web_Api.Controllers
{
    // Los controladores son el cerebro de una aplicación ASP.NET Core.
    // Procesan las solicitudes entrantes, realizan operaciones con los datos proporcionados
    // a través de los modelos y seleccionan las vistas para representar en el navegador.
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // La propiedad Mediator es una instancia del servicio Mediator que se obtiene a través de la inyección de dependencia.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
