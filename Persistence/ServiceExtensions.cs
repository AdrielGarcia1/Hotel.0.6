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
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de DbContext
            services.AddDbContext<HotelAppContex>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlServer"), c => c.MigrationsAssembly(typeof(HotelAppContex).Assembly.FullName)));

            // Inyección de dependencia para repositorios
            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(MyRepository<>));
            #endregion
        }
    }
}