using FluentValidation;

namespace ApplicationServices.Features.Clients.Commands.DeletClientCommand
{
    public class DeletClientComandValidator : AbstractValidator<DeletClientCommand>
    {
        public DeletClientComandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
