﻿using FluentValidation;
namespace ApplicationServices.Features.Recepcionists.Commands.UpdateRecepcionistCommand
{
    // Validador para el comando UpdateRecepcionistCommand
    public class UpdateRecepcionistCommandValidator : AbstractValidator<UpdateRecepcionistCommand>
    {
        public UpdateRecepcionistCommandValidator()
        {
            // Reglas de validación para el campo NameRecep
            RuleFor(x => x.NameRecep)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo LastNameRecep
            RuleFor(x => x.LastNameRecep)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo RDirection
            RuleFor(x => x.RDirection)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo EmailRecep
            RuleFor(x => x.EmailRecep)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una direccion de e-mail válida.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo DocumentRecep
            RuleFor(x => x.DocumentRecep)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[0-9]+").WithMessage("{PropertyName} solo debe contener números.")
                .MaximumLength(8).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo TelephoneRecep
            RuleFor(x => x.TelephoneRecep)
                .Matches(@"^[0-9]+").WithMessage("{PropertyName} solo debe contener números.")
                .MaximumLength(14).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.")
                .MinimumLength(6).WithMessage("{PropertyName} no debe contener menos de {MaxLength} caracteres.");

            // Reglas de validación para el campo Estate
            RuleFor(x => x.Estate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

            // Reglas de validación para el campo UserRecepId
            RuleFor(x => x.UserRecepId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }
}