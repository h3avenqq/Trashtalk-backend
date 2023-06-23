using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsList
{
    public class NewsListVm
    {
        public IList<NewsLookupDto> News { get; set; }
    }
}
