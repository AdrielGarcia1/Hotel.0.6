using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Estates.Commands.UpdateEstateCommand
{
    internal class UpdateEstateCommandValidator : AbstractValidator<UpdateEstateCommand>
    {
        public UpdateEstateCommandValidator()
        {
            RuleFor(a => a.NameEstate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}
