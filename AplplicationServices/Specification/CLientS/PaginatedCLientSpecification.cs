using ApplicationServices.filters.ClientsF;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.CLientS
{
    internal class PaginatedCLientSpecification : Specification<Client>
    {
        public PaginatedCLientSpecification(ClientResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NameClient
            if (!String.IsNullOrEmpty(filter.NameClient))
                Query.Search(x => x.NameClient, "%" + filter.NameClient + "%");

            // Realizar una búsqueda de coincidencia parcial en el campo LastNameClient
            if (!String.IsNullOrEmpty(filter.LastNameClient))
                Query.Search(x => x.LastNameClient, "%" + filter.LastNameClient + "%");

            // Filtrar las entidades marcadas como eliminadas si IsDeleted es true
            if (filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true);
            }
            else
            {
                // Filtrar las entidades no eliminadas si IsDeleted es false
                Query.Where(x => x.IsDeleted == false);
            }
        }
    }
}

