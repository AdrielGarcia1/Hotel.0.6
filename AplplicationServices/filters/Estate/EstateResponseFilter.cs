using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.Estate
{
    // Filtro de respuesta para las consultas de Estate
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes
    public class EstateResponseFilter : ParameterResponse
    {
        public string? NameEstate { get; set; } // Filtro por nombre de estado
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}