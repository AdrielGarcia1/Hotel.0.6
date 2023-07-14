using DomainClass.Common;
namespace DomainClass.Entity
{
    public class UserRecep : AuditableBaseEntity
    {
        public string NameUser { get; set; } // Nombre de usuario
        public string Password { get; set; } // Contraseña
        public string EmailRecep { get; set; } // Email del recepcionista
        public ICollection<Receptionist> Receptionists { get; set; } // Colección de recepcionistas asociados al usuario
    }
}