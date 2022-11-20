
using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IRoomServices
    {
        public Task<int> RoomDTOs(Room room);

    }
}
