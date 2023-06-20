using MediatR;
using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails
{
    public class GetTrashTypeDetailsQuery : IRequest<TrashTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
