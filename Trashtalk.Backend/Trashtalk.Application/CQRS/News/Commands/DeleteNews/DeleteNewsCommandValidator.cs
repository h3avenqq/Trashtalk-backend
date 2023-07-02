using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.DeleteNews
{
    public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
    {
        public DeleteNewsCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
