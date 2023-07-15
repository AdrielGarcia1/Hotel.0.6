namespace ApplicationServices.DTOs
{
    public class ReceptionistDTOs
    {
        // Esta clase representa un objeto de transferencia de datos (DTO) para un recepcionista.

        // Propiedad "NameRecep" que representa el nombre del recepcionista.
        public string NameRecep { get; set; }

        // Propiedad "LastNameRecep" que representa el apellido del recepcionista.
        public string LastNameRecep { get; set; }

        // Propiedad "RDirection" que representa la dirección del recepcionista.
        public string RDirection { get; set; }

        // Propiedad "EmailRecep" que representa el correo electrónico del recepcionista.
        public string EmailRecep { get; set; }

        // Propiedad "DocumentRecep" que representa el documento del recepcionista.
        public string DocumentRecep { get; set; }

        // Propiedad "TelephoneRecep" que representa el número de teléfono del recepcionista.
        public string TelephoneRecep { get; set; }

        // Propiedad "Estate" que representa el estado del recepcionista.
        public string Estate { get; set; }

        // Propiedad "Observation" que representa la observación o nota asociada al recepcionista.
        public string Observation { get; set; }

        // Propiedad "UserRecepId" que representa el identificador del usuario del recepcionista.
        public long UserRecepId { get; set; }

        // Propiedad "Id" que representa el identificador del recepcionista.
        public long Id { get; set; }
    }
}