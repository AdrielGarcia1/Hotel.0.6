using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Room : AuditableBaseEntity
    {
        public string NumberRoom { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public long TypesId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}