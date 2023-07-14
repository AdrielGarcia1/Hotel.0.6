using ApplicationServices.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    // Implementación de IRepository<T> utilizando RepositoryBase<T>
    public class MyRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly HotelAppContext dbContext; // Contexto de la base de datos

        public MyRepository(HotelAppContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
