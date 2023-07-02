using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.UpdateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(128);
            RuleFor(x => x.BriefDescription).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AuthorId).NotEqual(Guid.Empty);
        }
    }
}
