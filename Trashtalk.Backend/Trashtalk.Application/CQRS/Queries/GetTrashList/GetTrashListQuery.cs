using MediatR;

namespace Trashtalk.Application.CQRS.Queries.GetTrashList
{
    public class GetTrashListQuery : IRequest<TrashListVm>
    {
        //TODO:  Добавить количество и смещение для оптимизации
    }
}
