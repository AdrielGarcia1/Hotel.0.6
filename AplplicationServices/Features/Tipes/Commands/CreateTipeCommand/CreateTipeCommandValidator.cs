using FluentValidation;
namespace ApplicationServices.Features.Tipes.Commands.CreateTipeCommand
{
    public class CreateTipeCommandValidator : AbstractValidator<CreateTipeCommand>
    {
        public CreateTipeCommandValidator()
        {
            RuleFor(x => x.NameRoom)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.DescriptionRoom)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}
