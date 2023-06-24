using MediatR;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails
{
    public class GetUserTrashDetailsQuery : IRequest<UserTrashDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
