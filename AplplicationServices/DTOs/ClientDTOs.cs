namespace ApplicationServices.DTOs
{
    public class ClientDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para un cliente.

        // Propiedad "Id" que representa el identificador del cliente.
        public long Id { get; set; }

        // Propiedad "NameClient" que representa el nombre del cliente.
        public string NameClient { get; set; }

        // Propiedad "LastNameClient" que representa el apellido del cliente.
        public string LastNameClient { get; set; }

        // Propiedad "CDirection" que representa la dirección del cliente.
        public string CDirection { get; set; }

        // Propiedad "Email" que representa el correo electrónico del cliente.
        public string Email { get; set; }

        // Propiedad "TelephonoClient" que representa el número de teléfono del cliente.
        public string TelephonoClient { get; set; }
    }
}