using MediatR;
using System;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash
{
    public class CreateUserTrashCommand : IRequest<Guid>
    {
        public Guid TrashId { get; set; }
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
