using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.DeleteTrashType
{
    public class DeleteTrashTypeCommandValidator : AbstractValidator<DeleteTrashTypeCommand>
    {
        public DeleteTrashTypeCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
