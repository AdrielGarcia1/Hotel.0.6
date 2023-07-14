namespace ApplicationServices.Wrappers
{
    // Clase genérica que da formato a las respuestas de la Web API
    public class Response<T>
    {
        public Response() { } // Constructor predeterminado

        public Response(T data, string message = null!) // Constructor que establece la respuesta exitosa con datos y mensaje opcional
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }

        public Response(string message) // Constructor que establece la respuesta fallida con un mensaje
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; } // Indica si la respuesta fue exitosa
        public string Message { get; set; } // Mensaje de la respuesta
        public List<string> Errors { get; set; } // Lista de errores (opcional)
        public T Data { get; set; } // Datos de la respuesta (opcional)
    }
}