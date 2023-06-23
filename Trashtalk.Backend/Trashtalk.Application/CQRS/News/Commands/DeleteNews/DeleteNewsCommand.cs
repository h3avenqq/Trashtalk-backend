using MediatR;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
