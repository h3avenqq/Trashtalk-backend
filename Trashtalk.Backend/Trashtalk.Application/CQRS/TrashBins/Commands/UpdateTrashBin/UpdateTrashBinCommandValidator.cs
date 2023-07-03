using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.UpdateTrashBin
{
    public class UpdateTrashBinCommandValidator : AbstractValidator<UpdateTrashBinCommand>
    {
        public UpdateTrashBinCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Color).NotEmpty().MaximumLength(7).Matches(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }
    }
}
