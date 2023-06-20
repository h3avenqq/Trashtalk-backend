using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails
{
    public class GetTrashTypeDetailsQueryHandler : IRequestHandler<GetTrashTypeDetailsQuery, TrashTypeDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashTypeDetailsQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashTypeDetailsVm> Handle(GetTrashTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashType), request.Id);

            return _mapper.Map<TrashTypeDetailsVm>(entity);
        }
    }
}
