using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.UserRecep
{
    public class UserRecepResponseFilter : ParameterResponse
    {
        public string? NameUser { get; set; }
        public bool IsDeleted { get; set; }

    }
}
