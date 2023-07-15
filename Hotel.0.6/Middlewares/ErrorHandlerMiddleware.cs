using ApplicationServices.Exeptions;
using ApplicationServices.Wrappers;
using System.Net;
using System.Text.Json;

namespace Hotel_Web_Api.Middlewares
{
    // El middleware es un software que se ensambla en una canalización de aplicaciones
    // para manejar solicitudes y respuestas.
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                // Crea un objeto Response con el mensaje de error
                var responseModel = new Response<string>()
                {
                    Succeeded = false,
                    Message = error.Message
                };

                // Establece el código de estado y maneja diferentes tipos de excepciones
                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationExceptions e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                // Serializa el objeto Response en formato JSON y lo envía en la respuesta
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}