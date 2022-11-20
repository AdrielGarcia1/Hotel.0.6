using DomainClass.Common;
namespace DomainClass.Entity
{
    public class Client : AuditableBaseEntity
    {
        //private int _Edad;
        public string NameClient { get; set; }
        public string LastNameClient { get; set; }
        public string? CDirection { get; set; }
        public string Email { get; set; }
        public string? TelephonoClient { get; set; }
        public virtual ICollection <Rental> Rentals { get; set; }
        //public int Edad
        //{
        //    get
        //    {
        //        if (this._Edad <= 0)
        //        {
        //            this._Edad = new DateTime(DateTime.Now.Subtract(this.DateOfBirthClient).Ticks).Year - 1;
        //        }
        //        return this._Edad;
        //    }
        //}
    }
}