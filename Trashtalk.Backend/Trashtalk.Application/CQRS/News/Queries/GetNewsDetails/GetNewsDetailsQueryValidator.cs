using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQueryValidator : AbstractValidator<GetNewsDetailsQuery>
    {
        public GetNewsDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
