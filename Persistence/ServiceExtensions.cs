using ApplicationServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        // Agrega la infraestructura de persistencia a la colección de servicios de la aplicación
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de DbContext
            services.AddDbContext<HotelAppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MsSqlServer"),
                    c => c.MigrationsAssembly(typeof(HotelAppContext).Assembly.FullName)));

            // Inyección de dependencia para repositorios
            services.AddTransient(typeof(IRepository<>), typeof(MyRepository<>));
        }
    }
}