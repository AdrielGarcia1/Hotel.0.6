using ApplicationServices.filters.Rental;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.RentalS
{
    internal class PaginatedRentalSpecification : Specification<Rental>
    {
        public PaginatedRentalSpecification(RentalResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo TotalCost
            if (!String.IsNullOrEmpty(filter.TotalCost))
                Query.Search(x => x.TotalCost, "%" + filter.TotalCost + "%");

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