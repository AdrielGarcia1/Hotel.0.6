using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IRecepcionistService
    {
        // Interfaz para el servicio de recepcionistas (RecepcionistService)
        // Define un método para realizar la transformación y persistencia de un recepcionista (Receptionist)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> RecepcionistDTOs(Receptionist receptionist);
    }
}