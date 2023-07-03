using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.DeleteUserTrash
{
    public class DeleteUserTrashCommandValidator : AbstractValidator<DeleteUserTrashCommand>
    {
        public DeleteUserTrashCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
