using MediatR;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList
{
    public class GetUserTrashListQuery :  IRequest<UserTrashListVm>
    {
        public Guid UserId { get; set; }
    }
}
