using DomainClass.Entity;
namespace ApplicationServices.Services
{
    public interface IUserRecep
    {
        // Método para procesar los datos de UserRecep
        // y devuelve un entero que representa el resultado del procesamiento
        public Task<int> UserRecepDTOs(UserRecep userRecep);
    }
}