using ApplicationServices.Wrappers;

namespace ApplicationServices.filters.Rental
{
    public class RentalResponseFilter : ParameterResponse
    {
        public string? TotalCost { get; set; }
        public bool IsDeleted { get; set; }
    }
}
