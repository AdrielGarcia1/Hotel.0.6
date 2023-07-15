namespace ApplicationServices.DTOs
{
    public class RentalDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para un alquiler.

        // Propiedad "Id" que representa el identificador del alquiler.
        public long Id { get; set; }

        // Propiedad "DateAndhoursGet" que representa la fecha y hora de inicio del alquiler.
        public DateTime DateAndhoursGet { get; set; }

        // Propiedad "DateAndhoursSet" que representa la fecha y hora de finalización del alquiler.
        public DateTime DateAndhoursSet { get; set; }

        // Propiedad "TotalCost" que representa el costo total del alquiler.
        public string TotalCost { get; set; }

        // Propiedad "Observation" que representa la observación o nota asociada al alquiler.
        public string Observation { get; set; }

        // Propiedad "RoomId" que representa el identificador de la habitación asociada al alquiler.
        public int RoomId { get; set; }

        // Propiedad "ClientId" que representa el identificador del cliente asociado al alquiler.
        public int ClientId { get; set; }

        // Propiedad "ReceptionistId" que representa el identificador del recepcionista asociado al alquiler.
        public int ReceptionistId { get; set; }

        // Propiedad "EstateId" que representa el identificador del estado asociado al alquiler.
        public int EstateId { get; set; }
    }
}