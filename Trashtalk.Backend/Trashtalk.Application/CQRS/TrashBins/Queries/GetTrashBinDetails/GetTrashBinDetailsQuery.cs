using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinDetails
{
    public class GetTrashBinDetailsQuery : IRequest<TrashBinDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
