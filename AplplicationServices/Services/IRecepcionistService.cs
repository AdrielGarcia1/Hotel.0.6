using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IRecepcionistService
    {
        public Task<int> RecepcionistDTOs(Receptionist receptionist);

    }
}
