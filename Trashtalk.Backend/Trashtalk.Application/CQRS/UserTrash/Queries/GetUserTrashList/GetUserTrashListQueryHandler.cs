using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.UserTrash.Queries.GetUserTrashList
{
    public class GetUserTrashListQueryHandler : IRequestHandler<GetUserTrashListQuery, UserTrashListVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserTrashListQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserTrashListVm> Handle(GetUserTrashListQuery request, CancellationToken cancellationToken)
        {
            var query =
                await _dbContext.UserTrash.Where(x=>x.UserId==request.UserId)
                    .ProjectTo<UserTrashLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return new UserTrashListVm { UserTrash = query };
        }
    }
}
