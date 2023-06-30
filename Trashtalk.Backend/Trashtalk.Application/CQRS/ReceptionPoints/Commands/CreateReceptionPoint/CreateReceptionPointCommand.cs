using MediatR;
using System;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint
{
    public class CreateReceptionPointCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public GeoPoint Coordinates { get; set; }

    }
}
