using MediatR;
using System;

namespace Trashtalk.Application.CQRS.Trash.Commands.DeleteTrash
{
    public class DeleteTrashCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
