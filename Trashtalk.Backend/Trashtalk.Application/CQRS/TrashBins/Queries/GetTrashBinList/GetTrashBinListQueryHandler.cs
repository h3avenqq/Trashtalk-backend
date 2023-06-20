using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinList
{
    public class GetTrashBinListQueryHandler : IRequestHandler<GetTrashBinListQuery, TrashBinListVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashBinListQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashBinListVm> Handle(GetTrashBinListQuery request, CancellationToken cancellationToken)
        {
            var entities = 
                await _dbContext.TrashBins.ProjectTo<TrashBinLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new TrashBinListVm() { TrashBins = entities };
        }
    }
}
