using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Rental : AuditableBaseEntity
    {
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursGet { get; set; } // Fecha y hora de llegada
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursSet { get; set; } // Fecha y hora de salida
        public string TotalCost { get; set; } // Costo total del alquiler
        public string Observation { get; set; } // Observaciones
        public long RoomId { get; set; } // ID de la habitación asociada al alquiler
        public long ClientId { get; set; } // ID del cliente asociado al alquiler
        public long ReceptionistId { get; set; } // ID del recepcionista asociado al alquiler
        public long EstateId { get; set; } // ID del estado del alquiler
    }
}