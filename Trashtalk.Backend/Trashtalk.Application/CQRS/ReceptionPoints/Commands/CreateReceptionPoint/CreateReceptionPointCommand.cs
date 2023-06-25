using MediatR;
using System;
using NetTopologySuite.Geometries;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint
{
    public class CreateReceptionPointCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Point Coordinates { get; set; }

    }
}
