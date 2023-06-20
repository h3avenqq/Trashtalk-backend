using MediatR;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashList
{
    public class GetTrashListQuery : IRequest<TrashListVm>
    {
        //TODO:  Добавить количество и смещение для оптимизации
    }
}
