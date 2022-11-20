namespace ApplicationServices.DTOs
{
    public class ClientDTOs
    {
        //Un DTO es un objeto que define cómo se enviarán los datos a través de la red.
        public long Id { get; set; } 
        public string NameClient { get; set; }
        public string LastNameClient { get; set; }
        public string CDirection { get; set; }
        public string Email { get; set; }
        public string TelephonoClient { get; set; }
    }
}
