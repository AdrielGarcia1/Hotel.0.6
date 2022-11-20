using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.Tipe
{
    public class TipeResponseFilter : ParameterResponse
    {
        public string? NameRoom { get; set; }
        public bool IsDeleted { get; set; }
    }
}
