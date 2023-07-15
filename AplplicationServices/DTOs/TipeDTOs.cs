namespace ApplicationServices.DTOs
{
    public class TipeDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para un tipo de habitación.

        // Propiedad "Id" que representa el identificador del tipo de habitación.
        public long Id { get; set; }

        // Propiedad "NameRoom" que representa el nombre del tipo de habitación.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? NameRoom { get; set; }

        // Propiedad "DescriptionRoom" que representa la descripción del tipo de habitación.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? DescriptionRoom { get; set; }
    }
}