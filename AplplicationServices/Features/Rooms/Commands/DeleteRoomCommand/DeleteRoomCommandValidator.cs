using FluentValidation;

namespace ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand
{
    // Validador para el comando de eliminar una habitación
    internal class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull(); // La regla de validación asegura que el Id no esté vacío ni sea nulo
        }
    }
}