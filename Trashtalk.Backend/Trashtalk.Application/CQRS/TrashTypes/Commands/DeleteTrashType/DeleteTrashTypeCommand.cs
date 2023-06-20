using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.DeleteTrashType
{
    public class DeleteTrashTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
