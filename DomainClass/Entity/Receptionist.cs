using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Receptionist : AuditableBaseEntity
    {
        public string NameRecep { get; set; } // Nombre del recepcionista
        public string LastNameRecep { get; set; } // Apellido del recepcionista
        public string RDirection { get; set; } // Dirección del recepcionista
        public string EmailRecep { get; set; } // Email del recepcionista
        public string DocumentRecep { get; set; } // Documento del recepcionista
        public string TelephoneRecep { get; set; } // Teléfono del recepcionista
        public string Estate { get; set; } // Estado del recepcionista
        public string Observation { get; set; } // Observaciones
        public long UserRecepId { get; set; } // ID del usuario asociado al recepcionista
        public virtual ICollection<Rental>? Rentals { get; set; } // Colección de alquileres asociados al recepcionista
    }
}