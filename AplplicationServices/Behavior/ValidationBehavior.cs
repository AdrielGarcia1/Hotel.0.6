using FluentValidation;
using MediatR;

namespace ApplicationServices.Behavior
{
    //Clase se se encargara de controlar el comportamiento de las validaciones de las peticiones.
    //IRequest,IPipelineBehavior Interfaz propia De MEDIATR
    //Nos permite manejar las excepsiones
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        //Una dependencia es un objeto del que depende otro objeto. 
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Captura las excepciones
            if (_validator.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                //WhenAll: Crea una tarea que se completará cuando se hayan completado todas las tareas proporcionadas.
                var validationResult = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(v => v.Errors).Where(x => x != null).ToList();

                if (failures.Count != 0)
                {
                    //DEvuelve una excepcion generica o personalizadas de la clase ValidationExceptions
                    throw new Exeptions.ValidationExceptions(failures);
                }
            }
            return await next();
        }
    }
}
