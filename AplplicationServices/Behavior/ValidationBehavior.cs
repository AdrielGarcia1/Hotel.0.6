using FluentValidation;
using MediatR;
namespace ApplicationServices.Behavior
{
    // Esta clase se encarga de controlar el comportamiento de las validaciones de las peticiones.
    // Implementa la interfaz IPipelineBehavior de MediatR.
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        // Constructor que recibe una lista de validadores.
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Se verifica si existen validadores para la solicitud.
            if (_validator.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);

                // Se ejecutan las validaciones asincrónicas y se obtienen los resultados.
                var validationResult = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(context, cancellationToken)));

                // Se recopilan los errores de validación.
                var failures = validationResult.SelectMany(v => v.Errors).Where(x => x != null).ToList();

                // Si existen errores de validación, se lanza una excepción de tipo ValidationExceptions.
                if (failures.Count != 0)
                {
                    throw new Exeptions.ValidationExceptions(failures);
                }
            }

            // Se continúa con el siguiente manejador de la cadena de responsabilidad.
            return await next();
        }
    }
}