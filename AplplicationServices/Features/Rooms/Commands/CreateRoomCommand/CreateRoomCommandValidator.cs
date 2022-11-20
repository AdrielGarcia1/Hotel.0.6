using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;
namespace ApplicationServices.Features.Rooms.Commands.CreateRoomCommand
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.NumberRoom)
               .Matches(@"^[0-9]+").WithMessage("NumberRoom solo debe contener números.")
               .MaximumLength(5).WithMessage(" no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Cost)
               .Matches(@"^[0-9]+").WithMessage("Cost solo debe contener números.")
               .MaximumLength(7).WithMessage("Cost no debe exeder de {MaxLength} caracteres.")
               .MinimumLength(1).WithMessage("Cost no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.TypesId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }
}
