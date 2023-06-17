using MediatR;
using System;

namespace Trashtalk.Application.CQRS.Queries.GetTrashDetails
{
    public class GetTrashDetailsQuery : IRequest<TrashDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
