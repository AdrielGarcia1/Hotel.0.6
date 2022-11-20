using ApplicationServices.filters.Room;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.RoomS
{
    internal class PaginatedRoomSpecification : Specification<Room>
    {
        public PaginatedRoomSpecification(RoomResponseFilter filter)
        {
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.NumberRoom))
                Query.Search(x => x.NumberRoom, "%" + filter.NumberRoom + "%");

            if (!String.IsNullOrEmpty(filter.Cost))
                Query.Search(x => x.Cost, "%" + filter.Cost + "%");
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
