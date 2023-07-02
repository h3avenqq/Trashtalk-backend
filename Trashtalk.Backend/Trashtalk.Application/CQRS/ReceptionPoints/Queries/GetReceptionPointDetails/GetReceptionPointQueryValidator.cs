using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointDetails
{
    public class GetReceptionPointQueryValidator : AbstractValidator<GetReceptionPointDetailsQuery>
    {
        public GetReceptionPointQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
