﻿using MediatR;
using System;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.UpdateReceptionPoint
{
    public class UpdateReceptionPointCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public GeoPoint Coordinates { get; set; }
    }
}
