using DomainClass.Common;
using System.ComponentModel.DataAnnotations;
namespace DomainClass.Entity
{
    public class Types : AuditableBaseEntity
    {
        public string NameRoom { get; set; } // Nombre de la habitación
        public string DescriptionRoom { get; set; } // Descripción de la habitación
        public virtual ICollection<Room> rooms { get; set; } // Colección de habitaciones asociadas al tipo de habitación
        // Crear controladores de datos para obtener
    }
}