using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IEstateService
    {
        // Interfaz para el servicio de estados (EstateService)
        // Define un método para realizar la transformación y persistencia de un estado (Estate)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> EstateDTOs(Estate estate);
    }
}