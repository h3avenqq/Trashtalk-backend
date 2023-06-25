using System;
using MediatR;

namespace Trashtalk.Application.CQRS.Trash.Commands.CreateTrash
{
    public class CreateTrashCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public Guid TypeId { get; set; }
        public float Weight { get; set; }

    }
}
