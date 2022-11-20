using ApplicationServices.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class MyRepository <T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly HotelAppContex dbContext;

        public MyRepository(HotelAppContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
   
}
