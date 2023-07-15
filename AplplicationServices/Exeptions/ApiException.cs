using System.Globalization;
namespace ApplicationServices.Exeptions
{
    public class ApiException : Exception
    {
        // Esta clase representa una excepción personalizada llamada "ApiException".
        // Hereda de la clase base "Exception" que está definida en el espacio de nombres "System".

        // Constructor sin parámetros.
        // Crea una nueva instancia de la clase "ApiException".
        public ApiException() : base() { }

        // Constructor con un parámetro "message".
        // Crea una nueva instancia de la clase "ApiException" con un mensaje de error específico.
        public ApiException(string message) : base(message) { }

        // Constructor con parámetros "message" y "args".
        // Crea una nueva instancia de la clase "ApiException" con un mensaje de error formateado.
        // Utiliza la clase "String.Format" para formatear el mensaje con los argumentos proporcionados.
        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}