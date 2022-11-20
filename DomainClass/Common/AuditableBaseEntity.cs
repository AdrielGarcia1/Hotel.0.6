namespace DomainClass.Common
{
    public abstract class AuditableBaseEntity
    {
        //Clase madre de la cual van a heredar sus caracteristicas
        //las clases hijas de la carpeta Entity 
        public long Id { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
