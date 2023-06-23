using MediatR;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }

    }
}
