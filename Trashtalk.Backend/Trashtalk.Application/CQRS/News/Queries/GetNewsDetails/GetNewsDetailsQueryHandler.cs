using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQueryHandler : IRequestHandler<GetNewsDetailsQuery, NewsDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNewsDetailsQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NewsDetailsVm> Handle(GetNewsDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.News), request.Id);

            return _mapper.Map<NewsDetailsVm>(entity);
        }
    }
}
