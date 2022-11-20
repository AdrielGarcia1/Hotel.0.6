using ApplicationServices.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace ApplicationServices
{
    public static class ServiceExtensions
    {
        //Todos los servicios matriculados aca haciendo referencia a
        //"AddApplicationLayer" seran reflejados en Program de la WEBAPI
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Registrar los mapeos que haga en esta biblioteca de clase automaticamente 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //Implementa El patron Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
