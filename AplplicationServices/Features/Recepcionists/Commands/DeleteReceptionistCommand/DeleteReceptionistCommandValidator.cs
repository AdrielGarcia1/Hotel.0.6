using FluentValidation;

namespace ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand
{
    public class DeleteReceptionistCommandValidator : AbstractValidator<DeleteReceptionistCommand>
    {
        public DeleteReceptionistCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
