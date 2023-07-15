using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface ITipeServices
    {
        // Interfaz para el servicio de tipos de habitaciones (TipeServices)
        // Define un método para realizar la transformación y persistencia de un tipo de habitación (Types)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> TipeDTOs(Types types);
    }
}