using ApplicationServices.filters.Estate;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.EstateS
{
    internal class PaginatedStateSpecification : Specification<Estate>
    {
        public PaginatedStateSpecification(EstateResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NameEstate
            if (!String.IsNullOrEmpty(filter.NameEstate))
                Query.Search(x => x.NameEstate, "%" + filter.NameEstate + "%");

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