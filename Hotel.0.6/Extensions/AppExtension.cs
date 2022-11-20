using Hotel_Web_Api.Middlewares;
using System.Globalization;

namespace Hotel_Web_Api.Extensions
{
    public static class AppExtension
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();

        }
    }
}
