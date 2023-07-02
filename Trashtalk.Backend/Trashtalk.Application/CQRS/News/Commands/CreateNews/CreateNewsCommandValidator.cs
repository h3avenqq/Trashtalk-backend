using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.CreateNews
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(128);
            RuleFor(x => x.BriefDescription).NotEmpty().MaximumLength(250);
            RuleFor(x => x.AuthorId).NotEqual(Guid.Empty);
        }
    }
}
