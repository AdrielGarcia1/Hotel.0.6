using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Interfaces
{
    // Interfaz genérica para un repositorio que realiza operaciones de lectura y escritura en la base de datos
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {

    }

    // Interfaz genérica para un repositorio que realiza operaciones de lectura en la base de datos
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {

    }
}
