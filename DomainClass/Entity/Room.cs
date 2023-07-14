using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Room : AuditableBaseEntity
    {
        public string NumberRoom { get; set; } // Número de habitación
        public string Cost { get; set; } // Costo de la habitación
        public string Description { get; set; } // Descripción de la habitación
        public long TypesId { get; set; } // ID del tipo de habitación asociado
        public virtual ICollection<Rental> Rentals { get; set; } // Colección de alquileres asociados a la habitación
    }
}