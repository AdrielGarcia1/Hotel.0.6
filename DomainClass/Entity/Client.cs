using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Client : AuditableBaseEntity
    {
        // private int _Edad; (comentario eliminado)

        public string NameClient { get; set; } // Nombre del cliente
        public string LastNameClient { get; set; } // Apellido del cliente
        public string CDirection { get; set; } // Dirección del cliente (puede ser nulo)
        public string Email { get; set; } // Email del cliente
        public string TelephonoClient { get; set; } // Teléfono del cliente (puede ser nulo)
        public virtual ICollection<Rental>? Rentals { get; set; } // Colección de alquileres asociados al cliente
    }
}