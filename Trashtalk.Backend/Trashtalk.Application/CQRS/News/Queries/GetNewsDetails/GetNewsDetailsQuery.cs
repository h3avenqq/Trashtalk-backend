using MediatR;
using System;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQuery : IRequest<NewsDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
