using MediatR;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.DeleteUserTrash
{
    public class DeleteUserTrashCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
