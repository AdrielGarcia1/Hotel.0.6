namespace DomainClass.Common
{
    public abstract class AuditableBaseEntity
    {
        //Clase madre de la cual van a heredar sus caracteristicas
        //las clases hijas de la carpeta Entity 
        public long Id { get; set; } // Identificador de la entidad
        public long CreateBy { get; set; } // ID del usuario que creó la entidad
        public DateTime CreatedDate { get; set; } // Fecha y hora de creación de la entidad
        public long LastModifiedBy { get; set; } // ID del último usuario que modificó la entidad
        public DateTime LastModifiedDate { get; set; } // Fecha y hora de la última modificación de la entidad
        public bool IsDeleted { get; set; } // Indicador de si la entidad está marcada como eliminada
    }
}
