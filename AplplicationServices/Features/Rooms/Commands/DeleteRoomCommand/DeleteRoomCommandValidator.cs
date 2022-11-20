using FluentValidation;

namespace ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand
{
    internal class DeleteRoomCommandValidator : AbstractValidator <DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
