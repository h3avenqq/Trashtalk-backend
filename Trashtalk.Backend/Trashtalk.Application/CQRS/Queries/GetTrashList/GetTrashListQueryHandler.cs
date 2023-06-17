using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.Queries.GetTrashList
{
    public class GetTrashListQueryHandler : IRequestHandler<GetTrashListQuery, TrashListVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashListQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashListVm> Handle(GetTrashListQuery request, CancellationToken cancellationToken)
        {
            var entities =
                await _dbContext.Trash.ProjectTo<TrashLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new TrashListVm { Trash = entities};
        }
    }
}
