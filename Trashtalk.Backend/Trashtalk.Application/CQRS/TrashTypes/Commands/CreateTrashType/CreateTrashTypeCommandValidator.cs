using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.CreateTrashType
{
    public class CreateTrashTypeCommandValidator : AbstractValidator<CreateTrashTypeCommand>
    {
        public CreateTrashTypeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Algorithm).NotEmpty();
            RuleFor(x => x.TrashBinId).NotEqual(Guid.Empty);
        }
    }
}
