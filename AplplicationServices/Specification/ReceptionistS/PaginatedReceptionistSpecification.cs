using ApplicationServices.filters.Receptionist;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.ReceptionistS
{
    internal class PaginatedReceptionistSpecification : Specification<Receptionist>
    {
        public PaginatedReceptionistSpecification(ReceptionistResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameRecep))
                Query.Search(x => x.NameRecep, "%" + filter.NameRecep + "%");

            if (!String.IsNullOrEmpty(filter.LastNameRecep))
                Query.Search(x => x.LastNameRecep, "%" + filter.LastNameRecep + "%");
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
