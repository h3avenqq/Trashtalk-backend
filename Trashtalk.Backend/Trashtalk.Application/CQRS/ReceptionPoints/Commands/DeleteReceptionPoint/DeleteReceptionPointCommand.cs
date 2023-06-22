using MediatR;
using System;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.DeleteReceptionPoint
{
    public class DeleteReceptionPointCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
