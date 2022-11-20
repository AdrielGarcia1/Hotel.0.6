using ApplicationServices.Wrappers;
using MediatR;
using FluentValidation;

namespace ApplicationServices.Features.Rentals.Commands.CreateRentalCommand
{
    public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalCommandValidator()
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
            RuleFor(x => x.RoomId)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.ReceptionistId)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.EstateId)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

        }

    }
}
