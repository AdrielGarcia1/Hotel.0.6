using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Tipes.Commands.DeleteTipeCommand
{
    internal class DeleteTipeCommandValidator : AbstractValidator<DeleteTipeCommand>
    {
        public DeleteTipeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
