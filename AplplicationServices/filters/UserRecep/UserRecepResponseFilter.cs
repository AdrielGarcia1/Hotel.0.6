using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.UserRecep
{
    // Filtro de respuesta para las consultas de UserRecep
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes

    public class UserRecepResponseFilter : ParameterResponse
    {
        public string? NameUser { get; set; } // Filtro por nombre de usuario
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}