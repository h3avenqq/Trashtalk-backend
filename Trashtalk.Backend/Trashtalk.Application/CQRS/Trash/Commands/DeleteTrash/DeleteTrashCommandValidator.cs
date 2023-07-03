using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.Trash.Commands.DeleteTrash
{
    public class DeleteTrashCommandValidator : AbstractValidator<DeleteTrashCommand>
    {
        public DeleteTrashCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
