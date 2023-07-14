using ApplicationServices.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationServices
{
    public static class ServiceExtensions
    {
        // Todos los servicios registrados aquí usando "AddApplicationLayer" serán reflejados en el Program.cs de la WEBAPI

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // Registrar los mapeos definidos en esta biblioteca de clases automáticamente
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registrar los validadores definidos en esta biblioteca de clases automáticamente
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Implementar el patrón Mediator para manejar comandos y consultas
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Agregar el comportamiento de validación como un pipeline para los controladores
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}