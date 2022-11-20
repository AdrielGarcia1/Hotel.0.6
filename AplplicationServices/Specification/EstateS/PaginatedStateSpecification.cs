using ApplicationServices.filters.Estate;
using Ardalis.Specification;
using DomainClass.Entity;
namespace ApplicationServices.Specification.EstateS
{
    internal class PaginatedStateSpecification : Specification<Estate>
    {
        public PaginatedStateSpecification(EstateResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameEstate))
                Query.Search(x => x.NameEstate, "%" + filter.NameEstate + "%");
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
