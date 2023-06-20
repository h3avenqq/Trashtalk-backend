using MediatR;
using System;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails
{
    public class GetTrashDetailsQuery : IRequest<TrashDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
