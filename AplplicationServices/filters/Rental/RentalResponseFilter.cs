using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.Rental
{
    // Filtro de respuesta para las consultas de Rental
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes
    public class RentalResponseFilter : ParameterResponse
    {
        public string? TotalCost { get; set; }
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}