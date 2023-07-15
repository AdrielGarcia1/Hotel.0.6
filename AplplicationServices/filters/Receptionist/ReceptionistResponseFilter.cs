using ApplicationServices.Wrappers;
namespace ApplicationServices.filters.Receptionist
{
    // Filtro de respuesta para las consultas de Receptionist
    // Hereda de ParameterResponse para incluir la paginación y otros parámetros comunes
    public class ReceptionistResponseFilter : ParameterResponse
    {
        public string? NameRecep { get; set; } // Filtro por nombre de recepcionista
        public string? LastNameRecep { get; set; } // Filtro por apellido de recepcionista
        public bool IsDeleted { get; set; } // Filtro por estado de eliminación (eliminado o no eliminado)
    }
}