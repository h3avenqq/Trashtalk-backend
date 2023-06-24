using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashDetails
{
    public class GetUserTrashQueryHandler
        : IRequestHandler<GetUserTrashDetailsQuery, UserTrashDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserTrashQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserTrashDetailsVm> Handle(GetUserTrashDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.UserTrash.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Domain.UserTrash), request.Id);

            return _mapper.Map<UserTrashDetailsVm>(entity);
        }
    }
}
