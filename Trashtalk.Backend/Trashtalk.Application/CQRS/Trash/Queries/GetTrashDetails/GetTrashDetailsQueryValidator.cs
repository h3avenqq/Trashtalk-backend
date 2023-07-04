using FluentValidation;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails
{
    public class GetTrashDetailsQueryValidator : AbstractValidator<GetTrashDetailsQuery>
    {
        public GetTrashDetailsQueryValidator()
        {
            RuleFor(x => x.Barcode).NotEmpty().MaximumLength(256);
        }
    }
}
