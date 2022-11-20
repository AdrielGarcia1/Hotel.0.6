using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IRentalServices
    {
        public Task<int> RentalDTOs(Rental rental);

    }
}
