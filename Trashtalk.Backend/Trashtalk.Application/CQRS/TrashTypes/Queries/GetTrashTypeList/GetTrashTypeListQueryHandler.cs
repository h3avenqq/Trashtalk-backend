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

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList
{
    public class GetTrashTypeListQueryHandler : IRequestHandler<GetTrashTypeListQuery, TrashTypeListVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashTypeListQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashTypeListVm> Handle(GetTrashTypeListQuery request, CancellationToken cancellationToken)
        {
            var query =
                await _dbContext.TrashTypes
                    .ProjectTo<TrashTypeLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new TrashTypeListVm() { TrashTypes = query };
        }
    }
}
