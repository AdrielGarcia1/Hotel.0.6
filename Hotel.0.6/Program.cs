using ApplicationServices;
using Hotel_Web_Api.Extensions;
using Persistence;

// Crea el objeto 'builder' para configurar la aplicación web.
var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de inyección de dependencias.

builder.Services.AddControllers();

// Agrega la configuración para Swagger/OpenAPI.
// Aquí se podrían definir opciones adicionales para personalizar la documentación de la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega las capas de la aplicación.
// Esto incluye la capa de ApplicationServices y la capa de Persistence.
// Los métodos 'AddApplicationLayer' y 'AddPersistenceInfrastructure' son extensiones personalizadas definidas en el proyecto 'Hotel_Web_Api'.
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);

// Agrega la extensión para el versionado de la API.
builder.Services.AddApiVersioningExtension();

// Construye la aplicación.
var app = builder.Build();

// Configura el pipeline de solicitud HTTP.

if (app.Environment.IsDevelopment())
{
    // Habilita Swagger y Swagger UI en el entorno de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecciona las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Agrega la autenticación y autorización.
app.UseAuthorization();

// Agrega el middleware para manejar los errores de la aplicación.
app.UseErrorHandlerMiddleware();

// Mapea los controladores de la API.
app.MapControllers();

// Ejecuta la aplicación.
app.Run();