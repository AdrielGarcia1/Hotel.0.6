using FluentValidation;

namespace ApplicationServices.Features.Rentals.Commands.UpdateRentalCommand
{
    public class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
    {
        public UpdateRentalCommandValidator()
        {
            RuleFor(x => x.DateAndhoursGet)
            .NotEmpty();
            RuleFor(x => x.DateAndhoursSet)
            .NotEmpty();
            RuleFor(x => x.TotalCost)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
            .Matches(@"^[0-9]+").WithMessage("TotalCost solo debe contener números.")
            .MaximumLength(8).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Observation)
            .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.IdRoom)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.IdClient)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.ReceptionistId)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.IdState)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

        }

    }
}
