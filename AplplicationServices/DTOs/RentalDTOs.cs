using System.ComponentModel.DataAnnotations;
namespace ApplicationServices.DTOs
{
    public class RentalDTOs
    {
        public long Id { get; set; }
        public DateTime DateAndhoursGet { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursSet { get; set; }
        public string TotalCost { get; set; }
        public string Observation { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public int ReceptionistId { get; set; }
        public int EstateId { get; set; }
    }
}
