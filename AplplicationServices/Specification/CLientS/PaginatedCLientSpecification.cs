using ApplicationServices.filters.ClientsF;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.CLientS
{
    internal class PaginatedCLientSpecification : Specification<Client>
    {
        public PaginatedCLientSpecification(ClientResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameClient))
                Query.Search(x => x.NameClient, "%" + filter.NameClient + "%");

            if (!String.IsNullOrEmpty(filter.LastNameClient))
                Query.Search(x => x.LastNameClient, "%" + filter.LastNameClient + "%");

            if(filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true);
            }else
            {
                Query.Where(x => x.IsDeleted == false);
            }

        }

    }
}
