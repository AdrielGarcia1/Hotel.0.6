using ApplicationServices.filters.UserRecep;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.UserRecepS
{
    internal class PaginatedUserRecepSpecification : Specification<UserRecep>
    {
        public PaginatedUserRecepSpecification(UserRecepResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NameUser
            if (!String.IsNullOrEmpty(filter.NameUser))
                Query.Search(x => x.NameUser, "%" + filter.NameUser + "%");

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