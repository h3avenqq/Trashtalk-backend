using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.UpdateTrashType
{
    public class UpdateTrashTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }
    }
}
