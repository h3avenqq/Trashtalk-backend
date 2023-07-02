using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsList
{
    public class GetNewsListQueryValidator : AbstractValidator<GetNewsListQuery>
    {
        public GetNewsListQueryValidator()
        {

        }
    }
}
