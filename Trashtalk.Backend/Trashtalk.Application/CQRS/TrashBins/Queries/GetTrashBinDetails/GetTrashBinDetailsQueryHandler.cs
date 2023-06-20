using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinDetails
{
    public class GetTrashBinDetailsQueryHandler 
        : IRequestHandler<GetTrashBinDetailsQuery, TrashBinDetailsVm>
    {
        private readonly ITrashTalkDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrashBinDetailsQueryHandler(ITrashTalkDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TrashBinDetailsVm> Handle(GetTrashBinDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashBins.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashBin), request.Id);

            return _mapper.Map<TrashBinDetailsVm>(entity);
        }
    }
}
