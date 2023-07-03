using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails
{
    public class GetTrashTypeDetailsQueryValidator : AbstractValidator<GetTrashTypeDetailsQuery>
    {
        public GetTrashTypeDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
