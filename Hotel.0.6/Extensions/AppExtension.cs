using Hotel_Web_Api.Middlewares;
using System.Globalization;

namespace Hotel_Web_Api.Extensions
{
    public static class AppExtension
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            // Agrega el middleware de manejo de errores a la canalización de solicitud y respuesta de la aplicación
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}