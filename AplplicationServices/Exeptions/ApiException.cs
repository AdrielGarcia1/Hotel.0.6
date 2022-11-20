using System.Globalization;

namespace ApplicationServices.Exeptions
{
    public class ApiException : Exception
    {
        //muestra seguimientos detallados de la pila para detectar errores de servidor.
        //Utiliza DeveloperExceptionPageMiddleware para capturar excepciones sincrónicas
        //y asincrónicas de la canalización HTTP y para generar respuestas de error.
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
