using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.UpdateTrashBin
{
    public class UpdateTrashBinCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
