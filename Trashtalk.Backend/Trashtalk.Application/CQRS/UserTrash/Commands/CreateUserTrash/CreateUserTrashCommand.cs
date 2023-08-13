using MediatR;
using System;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash
{
    public class CreateUserTrashCommand : IRequest<Guid>
    {
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public GeoPoint Coordinates { get; set; }
    }
}
