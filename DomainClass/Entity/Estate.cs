using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Estate : AuditableBaseEntity
    {
        public string? NameEstate { get; set; } // Nombre del estado
        public virtual ICollection<Rental>? Rentals { get; set; } // Colección de alquileres asociados al estado
    }
}