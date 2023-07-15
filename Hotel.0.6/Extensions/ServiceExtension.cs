using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web_Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            // Agrega la configuración de versionado de la API al servicio de la aplicación
            services.AddApiVersioning(config =>
            {
                // Establece la versión API predeterminada
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // Asigna la versión predeterminada cuando no se especifica ninguna versión en la solicitud
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Habilita el informe de versiones API
                config.ReportApiVersions = true;
            });
        }
    }
}