using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Tipes.Commands.UpdateTipeCommand
{
    internal class UpdateTipeCommandValidator : AbstractValidator<UpdateTipeCommand>
    {
        public UpdateTipeCommandValidator()
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
