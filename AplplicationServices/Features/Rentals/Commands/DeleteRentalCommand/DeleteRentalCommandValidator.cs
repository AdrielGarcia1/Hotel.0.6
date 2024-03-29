﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand
{
    // Validador para el comando DeleteRentalCommand
    public class DeleteRentalCommandValidator : AbstractValidator<DeleteRentalCommand>
    {
        public DeleteRentalCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull(); // Regla de validación: el campo Id no debe estar vacío o nulo
        }
    }
}