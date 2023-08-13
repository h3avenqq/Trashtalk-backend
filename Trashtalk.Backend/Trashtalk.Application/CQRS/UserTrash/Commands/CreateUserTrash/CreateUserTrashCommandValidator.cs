using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash
{
    public class CreateUserTrashCommandValidator : AbstractValidator<CreateUserTrashCommand>
    {
        public CreateUserTrashCommandValidator()
        {
            RuleFor(x => x.TrashId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Coordinates).NotNull();
        }
    }
}
