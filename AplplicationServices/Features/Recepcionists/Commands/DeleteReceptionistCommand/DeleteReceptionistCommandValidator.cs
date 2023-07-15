using FluentValidation;
namespace ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand
{
    // Validador para el comando de eliminación de Receptionist
    public class DeleteReceptionistCommandValidator : AbstractValidator<DeleteReceptionistCommand>
    {
        public DeleteReceptionistCommandValidator()
        {
            // Regla de validación: El Id no debe estar vacío o nulo
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}