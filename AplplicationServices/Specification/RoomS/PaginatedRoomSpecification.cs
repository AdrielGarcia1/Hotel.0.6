using ApplicationServices.filters.Room;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationServices.Specification.RoomS
{
    internal class PaginatedRoomSpecification : Specification<Room>
    {
        public PaginatedRoomSpecification(RoomResponseFilter filter)
        {
            // Aplicar la paginación en la consulta
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                 .Take(filter.PageSize);

            // Realizar una búsqueda de coincidencia parcial en el campo NumberRoom
            if (!String.IsNullOrEmpty(filter.NumberRoom))
                Query.Search(x => x.NumberRoom, "%" + filter.NumberRoom + "%");

            // Realizar una búsqueda de coincidencia parcial en el campo Cost
            if (!String.IsNullOrEmpty(filter.Cost))
                Query.Search(x => x.Cost, "%" + filter.Cost + "%");

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