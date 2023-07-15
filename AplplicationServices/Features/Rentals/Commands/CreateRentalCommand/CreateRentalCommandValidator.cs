using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;
namespace ApplicationServices.Features.Rentals.Commands.CreateRentalCommand
{
    // Validador para el comando de creación de alquiler
    public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalCommandValidator()
        {
            // Reglas de validación para las propiedades del comando
            RuleFor(x => x.DateAndhoursGet)
                .NotEmpty(); // La fecha y hora de inicio del alquiler no debe estar vacía
            RuleFor(x => x.DateAndhoursSet)
                .NotEmpty(); // La fecha y hora de finalización del alquiler no debe estar vacía
            RuleFor(x => x.TotalCost)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // El costo total no debe estar vacío
                .Matches(@"^[0-9]+").WithMessage("TotalCost solo debe contener números.") // El costo total debe contener solo números
                .MaximumLength(8).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // El costo total no debe exceder de 8 caracteres
            RuleFor(x => x.Observation)
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // La observación no debe exceder de 200 caracteres
            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El Id de la habitación no debe estar vacío
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El Id del cliente no debe estar vacío
            RuleFor(x => x.ReceptionistId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El Id del recepcionista no debe estar vacío
            RuleFor(x => x.EstateId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El Id del estado no debe estar vacío
        }
    }
}