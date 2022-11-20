using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.Receptionist
{
    public class ReceptionistResponseFilter : ParameterResponse
    {
        public string? NameRecep { get; set; }
        public string? LastNameRecep { get; set; }
        public bool IsDeleted { get; set; }
    }
}
