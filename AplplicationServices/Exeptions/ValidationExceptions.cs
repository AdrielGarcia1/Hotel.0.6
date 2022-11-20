using FluentValidation.Results;

namespace ApplicationServices.Exeptions
{
    public class ValidationExceptions : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationExceptions() : base("Existen uno o más errores de validación.")
        {
            Errors = new List<string>();
        }
        //Recolecta las validaciones que larga "ValidationFailure"
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            //Recorre todos los errores y lo va agregando al listado de errores
            foreach (var failure in failures)
            {
                //Imprime el ErrorMessage
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
