using System.ComponentModel.DataAnnotations;
namespace ApplicationServices.DTOs
{
    public class RoomDTOs
    {
        public long Id { get; set; }
        public string? NumberRoom { get; set; }
        public string? Cost { get; set; }
        public string? Description { get; set; }
        public long TypesId { get; set; }

    }
}