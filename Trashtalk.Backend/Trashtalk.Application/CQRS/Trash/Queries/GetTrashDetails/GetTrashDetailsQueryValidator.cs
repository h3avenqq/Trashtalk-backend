using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails
{
    public class GetTrashDetailsQueryValidator : AbstractValidator<GetTrashDetailsQuery>
    {
        public GetTrashDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
