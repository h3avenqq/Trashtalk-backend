using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.CreateTrashType
{
    public class CreateTrashTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }
    }
}
