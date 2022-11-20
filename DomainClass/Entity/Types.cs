using DomainClass.Common;
using System.ComponentModel.DataAnnotations;
namespace DomainClass.Entity
{
    public class Types : AuditableBaseEntity
    {
        public string NameRoom { get; set; }
        public string DescriptionRoom { get; set; }
        public virtual ICollection<Room> rooms { get; set; }//Crear controladores datos para obtener
    }
}