using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IEstateService
    {
        public Task<int> EstateDTOs(Estate estate);
    }
}
