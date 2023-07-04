using System;
using MediatR;

namespace Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash
{
    public class UpdateTrashCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Weight { get; set; }
        public Guid TypeId { get; set; }
    }
}
