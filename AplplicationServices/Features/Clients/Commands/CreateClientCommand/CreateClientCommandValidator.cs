using FluentValidation;
namespace ApplicationServices.Features.Clients.Commands.CreateClientCommand
{
    // Validador para el comando CreateClientCommand
    // Implementa AbstractValidator<CreateClientCommand> para validar los datos del comando
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.NameClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // Validación de no vacío para el nombre del cliente
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres."); // Validación de longitud máxima para el nombre del cliente

            RuleFor(x => x.LastNameClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // Validación de no vacío para el apellido del cliente
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres."); // Validación de longitud máxima para el apellido del cliente

            RuleFor(x => x.CDirection)
                .NotEmpty() // Validación de no vacío para la dirección del cliente
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres."); // Validación de longitud máxima para la dirección del cliente

            RuleFor(x => x.TelephonoClient)
                .Matches(@"^[0-9]+").WithMessage("Teléfono solo debe contener números.") // Validación de formato numérico para el teléfono del cliente
                .MaximumLength(14).WithMessage("Teléfono no debe exceder de {MaxLength} caracteres.") // Validación de longitud máxima para el teléfono del cliente
                .MinimumLength(6).WithMessage("Teléfono no debe contener menos de {MaxLength} caracteres."); // Validación de longitud mínima para el teléfono del cliente

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.") // Validación de no vacío para el email del cliente
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una dirección de e-mail válida.") // Validación de formato de email válido
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres."); // Validación de longitud máxima para el email del cliente
        }
    }
}