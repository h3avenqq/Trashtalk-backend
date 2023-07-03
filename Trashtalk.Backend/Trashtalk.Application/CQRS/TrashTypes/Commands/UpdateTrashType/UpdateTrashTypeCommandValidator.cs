using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.UpdateTrashType
{
    public class UpdateTrashTypeCommandValidator : AbstractValidator<UpdateTrashTypeCommand>
    {
        public UpdateTrashTypeCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Algorithm).NotEmpty();
            RuleFor(x => x.TrashBinId).NotEqual(Guid.Empty);
        }
    }
}
