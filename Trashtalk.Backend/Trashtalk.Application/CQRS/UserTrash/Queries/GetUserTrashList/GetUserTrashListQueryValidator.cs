using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList
{
    public class GetUserTrashListQueryValidator : AbstractValidator<GetUserTrashListQuery>
    {
        public GetUserTrashListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
