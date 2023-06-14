using System;
using MediatR;

namespace Trashtalk.Application.CQRS.Commands.UpdateTrash
{
    public class UpdateTrashCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public Guid TypeId { get; set; }
    }
}
