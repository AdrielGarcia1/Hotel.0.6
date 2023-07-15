using ApplicationServices.filters.Receptionist;
using Ardalis.Specification;
using DomainClass.Entity;
namespace ApplicationServices.Specification.ReceptionistS
{
    internal class PaginatedReceptionistSpecification : Specification<Receptionist>
    {
        public PaginatedReceptionistSpecification(ReceptionistResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NameRecep
            if (!String.IsNullOrEmpty(filter.NameRecep))
                Query.Search(x => x.NameRecep, "%" + filter.NameRecep + "%");

            // Realizar una búsqueda de coincidencia parcial en el campo LastNameRecep
            if (!String.IsNullOrEmpty(filter.LastNameRecep))
                Query.Search(x => x.LastNameRecep, "%" + filter.LastNameRecep + "%");

            // Filtrar las entidades marcadas como eliminadas si IsDeleted es true
            if (filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true); // Filtrar las entidades marcadas como eliminadas
            }
            else
            {
                Query.Where(x => x.IsDeleted == false); // Filtrar las entidades no eliminadas
            }
        }
    }
}