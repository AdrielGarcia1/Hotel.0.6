using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationServices.Features.Estates.Commands.UpdateEstateCommand
{
    // Validador para el comando UpdateEstateCommand
    internal class UpdateEstateCommandValidator : AbstractValidator<UpdateEstateCommand>
    {
        public UpdateEstateCommandValidator()
        {
            // Reglas de validación para el campo NameEstate
            RuleFor(a => a.NameEstate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
        }
    }
}