using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IRentalServices
    {
        // Interfaz para el servicio de alquileres (RentalServices)
        // Define un método para realizar la transformación y persistencia de un alquiler (Rental)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> RentalDTOs(Rental rental);
    }
}