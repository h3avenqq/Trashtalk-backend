using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.DeleteTrashBin
{
    public class DeleteTrashBinCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
