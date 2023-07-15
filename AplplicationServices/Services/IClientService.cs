using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IClientService
    {
        // Interfaz para el servicio de clientes (ClientService)
        // Define un método para realizar la transformación y persistencia de un cliente (Client)
        // Retorna un valor entero que indica el resultado de la operación

        public Task<int> ClientDTOs(Client client);
    }
}