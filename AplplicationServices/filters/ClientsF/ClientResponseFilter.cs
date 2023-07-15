using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.ClientsF
{
    // Filtro de respuesta para las consultas de Client
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes
    public class ClientResponseFilter : ParameterResponse
    {
        public string? NameClient { get; set; } // Filtro por nombre de cliente
        public string? LastNameClient { get; set; } // Filtro por apellido de cliente
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}
