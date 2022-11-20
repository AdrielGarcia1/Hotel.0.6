using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.Estate
{
    public class EstateResponseFilter :ParameterResponse
    {
        public string? NameEstate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
