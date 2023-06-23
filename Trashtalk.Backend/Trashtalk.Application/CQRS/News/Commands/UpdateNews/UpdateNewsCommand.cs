using MediatR;
using System;

namespace Trashtalk.Application.CQRS.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}
