using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.UpdateReceptionPoint
{
    public class UpdateReceptionPointCommandValidator : AbstractValidator<UpdateReceptionPointCommand>
    {
        public UpdateReceptionPointCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Address).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Coordinates).NotNull();
        }
    }
}
