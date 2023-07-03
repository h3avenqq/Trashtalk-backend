using FluentValidation;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.CreateTrashBin
{
    public class CreateTrashBinCommandValidator : AbstractValidator<CreateTrashBinCommand>
    {
        public CreateTrashBinCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Color).NotEmpty().MaximumLength(7).Matches(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }
    }
}
