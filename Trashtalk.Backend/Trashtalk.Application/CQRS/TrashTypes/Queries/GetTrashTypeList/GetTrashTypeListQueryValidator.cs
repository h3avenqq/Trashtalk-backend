using FluentValidation;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList
{
    public class GetTrashTypeListQueryValidator : AbstractValidator<GetTrashTypeListQuery>
    {
        public GetTrashTypeListQueryValidator()
        {

        }
    }
}
