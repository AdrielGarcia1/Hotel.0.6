using ApplicationServices.filters.UserRecep;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.UserRecepS
{
    internal class PaginatedUserRecepSpecification : Specification<UserRecep>
    {
     public PaginatedUserRecepSpecification(UserRecepResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameUser))
                Query.Search(x => x.NameUser, "%" + filter.NameUser + "%");
            if (filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true);
            }
            else
            {
                Query.Where(x => x.IsDeleted == false);
            }
        }

    }
}
