using FluentValidation;
namespace ApplicationServices.Features.Tipes.Commands.CreateTipeCommand
{
    // Validador para el comando CreateTipeCommand
    public class CreateTipeCommandValidator : AbstractValidator<CreateTipeCommand>
    {
        public CreateTipeCommandValidator()
        {
            // Regla de validación para el campo NameRoom
            RuleFor(x => x.NameRoom)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            // Regla de validación para el campo DescriptionRoom
            RuleFor(x => x.DescriptionRoom)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
        }
    }
}