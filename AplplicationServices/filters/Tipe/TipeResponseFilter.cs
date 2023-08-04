using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.Types
{
    // Filtro de respuesta para las consultas de Tipe
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes

    public class TipeResponseFilter : ParameterResponse
    {
        public string? NameRoom { get; set; } // Filtro por nombre de habitación
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}