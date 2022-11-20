using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Rooms.Commands.UpdateRoomCommand
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.NumberRoom)
               .Matches(@"^[0-9]+").WithMessage("NumberRoom solo debe contener números.")
               .MaximumLength(5).WithMessage(" no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Cost)
               .Matches(@"^[0-9]+").WithMessage("Cost solo debe contener números.")
               .MaximumLength(8).WithMessage("Cost no debe exeder de {MaxLength} caracteres.")
               .MinimumLength(1).WithMessage("Cost no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.TypesId)
                .NotEmpty();
        }
    }
}
