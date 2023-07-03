using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash
{
    public class UpdateTrashCommandValidator : AbstractValidator<UpdateTrashCommand>
    {
        public UpdateTrashCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Barcode).NotEmpty();
            RuleFor(x => x.Weight).NotNull().Must(x => x > 0);
        }
    }
}
