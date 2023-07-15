using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.Room
{
    // Filtro de respuesta para las consultas de Room
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes

    public class RoomResponseFilter : ParameterResponse
    {
        public string? NumberRoom { get; set; } // Filtro por número de habitación
        public string? Cost { get; set; } // Filtro por costo de habitación
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}