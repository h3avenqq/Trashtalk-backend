using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.Trash.Commands.CreateTrash
{
    public class CreateTrashCommandValidator : AbstractValidator<CreateTrashCommand>
    {
        public CreateTrashCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Barcode).NotEmpty().MaximumLength(256);
            RuleFor(x => x.TypeId).NotEqual(Guid.Empty);
            RuleFor(x => x.Weight).NotNull().Must(x => x > 0);
        }
    }
}
