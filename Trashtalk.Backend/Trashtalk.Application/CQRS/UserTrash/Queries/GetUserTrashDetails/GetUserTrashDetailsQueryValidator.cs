using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails
{
    public class GetUserTrashDetailsQueryValidator : AbstractValidator<GetUserTrashDetailsQuery>
    {
        public GetUserTrashDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
