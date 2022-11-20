using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.Room
{
    public class RoomResponseFilter : ParameterResponse
    {
        public string? NumberRoom { get; set; }
        public string? Cost { get; set; }
        public bool IsDeleted { get; set; }
    }
}
