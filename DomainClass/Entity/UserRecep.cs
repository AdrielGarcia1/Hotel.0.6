using DomainClass.Common;
namespace DomainClass.Entity
{
    public class UserRecep : AuditableBaseEntity
    {
        public string NameUser { get; set; }
        public string Password { get; set; }
        public string EmailRecep { get; set; }
        public ICollection<Receptionist> Receptionists { get; set; }
    }
}