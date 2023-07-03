using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.DeleteTrashBin
{
    public class DeleteTrashBinCommandValidator : AbstractValidator<DeleteTrashBinCommand>
    {
        public DeleteTrashBinCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
