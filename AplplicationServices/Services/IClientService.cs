using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IClientService
    {
        public Task<int> ClientDTOs(Client client);
    }
}
