namespace ApplicationServices.DTOs
{
    public class UserRecepDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para un usuario de recepción.

        // Propiedad "Id" que representa el identificador del usuario de recepción.
        public long Id { get; set; }

        // Propiedad "NameUser" que representa el nombre de usuario del usuario de recepción.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? NameUser { get; set; }

        // Propiedad "Password" que representa la contraseña del usuario de recepción.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? Password { get; set; }

        // Propiedad "EmailRecep" que representa el correo electrónico del usuario de recepción.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? EmailRecep { get; set; }
    }
}