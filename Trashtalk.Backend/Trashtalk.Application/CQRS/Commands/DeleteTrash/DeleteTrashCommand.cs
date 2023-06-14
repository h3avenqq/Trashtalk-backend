using MediatR;
using System;

namespace Trashtalk.Application.CQRS.Commands.DeleteTrash
{
    public class DeleteTrashCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
