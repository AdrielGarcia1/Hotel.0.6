using ApplicationServices.filters.Tipe;
using Ardalis.Specification;
using DomainClass.Entity;
namespace ApplicationServices.Specification.TipeS
{
    internal class PaginatedTipeSpecification : Specification<Types>
    {
        public PaginatedTipeSpecification(TipeResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NameRoom))
                Query.Search(x => x.NameRoom, "%" + filter.NameRoom + "%");
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
