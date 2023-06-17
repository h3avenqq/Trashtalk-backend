using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.Queries.GetTrashDetails
{
    public class GetTrashDetailsQueryHandler 
        : IRequestHandler<GetTrashDetailsQuery, TrashDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashDetailsQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashDetailsVm> Handle(GetTrashDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Trash.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trash), request.Id);

            return _mapper.Map<TrashDetailsVm>(entity);
        }
    }
}
