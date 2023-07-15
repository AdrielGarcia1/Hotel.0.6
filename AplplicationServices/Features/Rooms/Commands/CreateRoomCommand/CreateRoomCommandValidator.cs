using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;
namespace ApplicationServices.Features.Rooms.Commands.CreateRoomCommand
{
    // Validador del comando para crear una habitación
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.NumberRoom)
               .Matches(@"^[0-9]+").WithMessage("NumberRoom solo debe contener números.")   // Validar que el campo NumberRoom contenga solo números
               .MaximumLength(5).WithMessage(" no debe exeder de {MaxLength} caracteres."); // Validar que el campo NumberRoom no exceda cierta longitud

            RuleFor(x => x.Cost)
               .Matches(@"^[0-9]+").WithMessage("Cost solo debe contener números.")   // Validar que el campo Cost contenga solo números
               .MaximumLength(7).WithMessage("Cost no debe exeder de {MaxLength} caracteres.") // Validar que el campo Cost no exceda cierta longitud
               .MinimumLength(1).WithMessage("Cost no debe contener menos de {MaxLength} caracteres."); // Validar que el campo Cost no tenga menos de cierta longitud

            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")  // Validar que el campo Description no esté vacío
               .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // Validar que el campo Description no exceda cierta longitud

            RuleFor(x => x.TypesId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");  // Validar que el campo TypesId no esté vacío
        }
    }
}