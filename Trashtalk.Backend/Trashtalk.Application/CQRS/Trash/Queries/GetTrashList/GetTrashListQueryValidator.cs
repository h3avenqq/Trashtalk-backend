using FluentValidation;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashList
{
    public class GetTrashListQueryValidator : AbstractValidator<GetTrashListQuery>
    {
        public GetTrashListQueryValidator()
        {
            
        }
    }
}
