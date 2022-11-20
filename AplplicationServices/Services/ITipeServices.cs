using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface ITipeServices
    {
        public Task<int> TipeDTOs(Types types);
    }
}
