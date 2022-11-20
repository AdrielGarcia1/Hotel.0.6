using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Rental : AuditableBaseEntity
    {
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursGet{ get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursSet { get; set; }
        public string TotalCost { get; set; }
        public string Observation { get; set; }
        public long RoomId { get; set; }
        public long ClientId { get; set; }
        public long ReceptionistId { get; set; }
        public long EstateId { get; set; }

    }
}
