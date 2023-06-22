using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Queries.GetReceptionPointDetails
{
    public class GetReceptionPointDetailsQueryHandler 
        : IRequestHandler<GetReceptionPointDetailsQuery, ReceptionPointDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReceptionPointDetailsQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ReceptionPointDetailsVm> Handle(GetReceptionPointDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ReceptionPoints.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ReceptionPoint), request.Id);

            return _mapper.Map<ReceptionPointDetailsVm>(entity);
        }
    }
}
