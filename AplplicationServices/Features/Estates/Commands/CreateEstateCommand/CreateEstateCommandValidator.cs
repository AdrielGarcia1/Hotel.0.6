using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;
namespace ApplicationServices.Features.Estates.Commands.CreateEstateCommand
{
    public class CreateEstateCommandValidator : AbstractValidator<CreateEstateCommand>
    {
        public CreateEstateCommandValidator()
        {
            // Se define la regla de validación para el campo NameEstate
            RuleFor(a => a.NameEstate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // El campo no puede estar vacío
                .MaximumLength(10).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // El campo no debe exceder una longitud máxima de 10 caracteres
        }
    }
}