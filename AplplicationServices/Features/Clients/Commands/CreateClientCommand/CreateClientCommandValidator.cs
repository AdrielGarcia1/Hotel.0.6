using FluentValidation;

namespace ApplicationServices.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
    public  CreateClientCommandValidator()
        {
            RuleFor(x => x.NameClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.LastNameClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres."); ;
            RuleFor(x => x.CDirection)
                .NotEmpty()
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.TelephonoClient)
                .Matches(@"^[0-9]+").WithMessage("Teléfono solo debe contener números.")
                .MaximumLength(14).WithMessage("Teléfono no debe exeder de {MaxLength} caracteres.")
                .MinimumLength(6).WithMessage("Teléfono no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una direccion de e-mail válida.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }

    }
}
