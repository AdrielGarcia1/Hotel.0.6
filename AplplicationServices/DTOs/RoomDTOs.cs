namespace ApplicationServices.DTOs
{
    public class RoomDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para una habitación.

        // Propiedad "Id" que representa el identificador de la habitación.
        public long Id { get; set; }

        // Propiedad "NumberRoom" que representa el número de la habitación.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? NumberRoom { get; set; }

        // Propiedad "Cost" que representa el costo de la habitación.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? Cost { get; set; }

        // Propiedad "Description" que representa la descripción de la habitación.
        // El signo "?" indica que la propiedad puede ser nula.
        public string? Description { get; set; }

        // Propiedad "TypesId" que representa el identificador del tipo de habitación asociado a la habitación.
        public long TypesId { get; set; }
    }
}