using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.UpdateTrashBin
{
    public class UpdateTrashBinCommandHandler : IRequestHandler<UpdateTrashBinCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateTrashBinCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTrashBinCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashBins.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashBin), request.Id);

            entity.Name = request.Name;
            entity.Color = request.Color;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
