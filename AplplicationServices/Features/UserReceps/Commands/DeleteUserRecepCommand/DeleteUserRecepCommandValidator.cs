using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.UserReceps.Commands.DeleteUserRecepCommand
{
    internal class DeleteUserRecepCommandValidator : AbstractValidator <DeleteUserRecepCommand>
    {
        public DeleteUserRecepCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
