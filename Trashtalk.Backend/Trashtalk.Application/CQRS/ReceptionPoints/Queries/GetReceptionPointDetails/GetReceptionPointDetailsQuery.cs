using MediatR;
using System;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointDetails
{
    public class GetReceptionPointDetailsQuery : IRequest<ReceptionPointDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
