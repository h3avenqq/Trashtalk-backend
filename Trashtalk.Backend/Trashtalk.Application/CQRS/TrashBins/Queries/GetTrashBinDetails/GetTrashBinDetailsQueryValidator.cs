using FluentValidation;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinDetails
{
    public class GetTrashBinDetailsQueryValidator : AbstractValidator<GetTrashBinDetailsQuery>
    {
        public GetTrashBinDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
