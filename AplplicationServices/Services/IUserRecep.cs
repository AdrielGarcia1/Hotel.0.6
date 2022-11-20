using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IUserRecep
    {
        public Task<int> UserRecepDTOs(UserRecep userRecep);
    }
}
