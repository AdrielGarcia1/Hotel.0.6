using System.ComponentModel.DataAnnotations;
namespace ApplicationServices.DTOs
{
    public class TipeDTOs
    {
        public long Id { get; set; }
        public string? NameRoom { get; set; }
        public string? DescriptionRoom { get; set; }
    }
}