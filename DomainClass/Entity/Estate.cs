using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Estate : AuditableBaseEntity
    {
        public string NameEstate { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}