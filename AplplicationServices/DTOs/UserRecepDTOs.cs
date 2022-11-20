using System.ComponentModel.DataAnnotations;
namespace ApplicationServices.DTOs
{
    public class UserRecepDTOs
    {
        public long Id { get; set; }
        public string? NameUser { get; set; }
        public string? Password { get; set; }
        public string? EmailRecep { get; set; }
    }
}
