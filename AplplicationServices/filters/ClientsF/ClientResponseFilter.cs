 using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.ClientsF
{
    public class ClientResponseFilter : ParameterResponse
    {
        public string? NameClient { get; set; }
        public string? LastNameClient { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
