using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.CreateTrashBin
{
    public class CreateTrashBinCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
