using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.DeleteReceptionPoint
{
    public class DeleteReceptionPointCommandValidator : AbstractValidator<DeleteReceptionPointCommand>
    {
        public DeleteReceptionPointCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
