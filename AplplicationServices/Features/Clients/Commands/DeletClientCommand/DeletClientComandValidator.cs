using FluentValidation;
namespace ApplicationServices.Features.Clients.Commands.DeletClientCommand
{
    // Validador para el comando DeletClientCommand
    // Implementa AbstractValidator<DeletClientCommand> para validar los datos del comando
    public class DeletClientComandValidator : AbstractValidator<DeletClientCommand>
    {
        public DeletClientComandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull(); // Validación de no vacío y no nulo para el Id del cliente a eliminar
        }
    }
}