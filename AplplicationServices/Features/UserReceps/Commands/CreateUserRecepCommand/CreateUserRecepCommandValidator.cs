using FluentValidation;

namespace ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand
{
    public class CreateUserRecepCommandValidator : AbstractValidator<CreateUserRecepCommand>
    {
        public CreateUserRecepCommandValidator()
        {
            RuleFor(x => x.NameUser)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(15).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.")
                .MinimumLength(4).WithMessage("AdressUser no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.EmailRecep)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una direccion de e-mail válida.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
