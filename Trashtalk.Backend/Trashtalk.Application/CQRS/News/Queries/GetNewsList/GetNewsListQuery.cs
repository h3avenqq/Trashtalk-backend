using MediatR;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsList
{
    public class GetNewsListQuery : IRequest<NewsListVm>
    {

    }
}
