using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Receptionist : AuditableBaseEntity
    {
        public string NameRecep { get; set; }
        public string LastNameRecep { get; set; }
        public string RDirection { get; set; }
        public string EmailRecep { get; set; }
        public string DocumentRecep { get; set; }
        public string TelephoneRecep { get; set; }
        public string Estate { get; set; }
        public string Observation { get; set; }
        public long UserRecepId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}