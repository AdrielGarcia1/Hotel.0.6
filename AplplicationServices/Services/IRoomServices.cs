using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IRoomServices
    {
        // Interfaz para el servicio de habitaciones (RoomServices)
        // Define un método para realizar la transformación y persistencia de una habitación (Room)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> RoomDTOs(Room room);
    }
}