using ApplicationServices.filters.Rental;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.RentalS
{
    internal class PaginatedRentalSpecification : Specification<Rental>
    {
        public PaginatedRentalSpecification(RentalResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.TotalCost))
                Query.Search(x => x.TotalCost, "%" + filter.TotalCost + "%");
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
