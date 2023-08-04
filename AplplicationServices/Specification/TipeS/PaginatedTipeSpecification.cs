using ApplicationServices.filters.Types;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.TipeS
{
    internal class PaginatedTipeSpecification : Specification<Types>
    {
        public PaginatedTipeSpecification(TipeResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NameRoom
            if (!String.IsNullOrEmpty(filter.NameRoom))
                Query.Search(x => x.NameRoom, "%" + filter.NameRoom + "%");

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