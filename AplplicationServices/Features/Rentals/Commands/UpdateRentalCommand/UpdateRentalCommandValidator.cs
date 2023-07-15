using FluentValidation;
namespace ApplicationServices.Features.Rentals.Commands.UpdateRentalCommand
{
    public class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
    {
        public UpdateRentalCommandValidator()
        {
            RuleFor(x => x.DateAndhoursGet)
                .NotEmpty(); // La fecha y hora de inicio del alquiler no puede estar vacía

            RuleFor(x => x.DateAndhoursSet)
                .NotEmpty(); // La fecha y hora de fin del alquiler no puede estar vacía

            RuleFor(x => x.TotalCost)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // El costo total no puede estar vacío
                .Matches(@"^[0-9]+").WithMessage("TotalCost solo debe contener números.") // El costo total solo debe contener números
                .MaximumLength(8).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // El costo total no debe exceder los 8 caracteres

            RuleFor(x => x.Observation)
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); // La observación no debe exceder los 200 caracteres

            RuleFor(x => x.IdRoom)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El ID de la habitación no puede estar vacío

            RuleFor(x => x.IdClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El ID del cliente no puede estar vacío

            RuleFor(x => x.ReceptionistId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El ID del recepcionista no puede estar vacío

            RuleFor(x => x.IdState)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío."); // El ID del estado no puede estar vacío
        }
    }
}