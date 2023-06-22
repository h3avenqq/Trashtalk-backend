using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointList
{
    public class GetReceptionPointListQueryHandler : IRequestHandler<GetReceptionPointListQuery, ReceptionPointListVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReceptionPointListQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ReceptionPointListVm> Handle(GetReceptionPointListQuery request, CancellationToken cancellationToken)
        {
            var query =
                await _dbContext.ReceptionPoints
                    .ProjectTo<ReceptionPointLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return new ReceptionPointListVm { ReceptionPoints = query };
        }
    }
}
