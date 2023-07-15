using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationServices.Features.Estates.Commands.DeletEstateCommand
{
    public class DeletStateCommandValidator : AbstractValidator<DeletStateCommand>
    {
        public DeletStateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull(); // Validación: El campo "Id" no debe estar vacío ni nulo.
        }
    }
}