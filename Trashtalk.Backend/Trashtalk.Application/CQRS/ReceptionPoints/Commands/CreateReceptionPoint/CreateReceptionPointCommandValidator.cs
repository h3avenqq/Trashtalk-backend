using FluentValidation;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint
{
    public class CreateReceptionPointCommandValidator : AbstractValidator<CreateReceptionPointCommand>
    {
        public CreateReceptionPointCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Address).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Coordinates).NotNull();
        }
    }
}
