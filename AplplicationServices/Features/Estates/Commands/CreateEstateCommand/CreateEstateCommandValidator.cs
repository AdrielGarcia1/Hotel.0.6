using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;
namespace ApplicationServices.Features.Estates.Commands.CreateEstateCommand
{
    public class CreateEstateCommandValidator : AbstractValidator<CreateEstateCommand>
    {
        public CreateEstateCommandValidator()
        {
            RuleFor(a => a.NameEstate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }

    }
}
