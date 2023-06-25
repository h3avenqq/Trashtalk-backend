using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.DeleteTrashBin
{
    public class DeleteTrashBinCommandHandler : IRequestHandler<DeleteTrashBinCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public DeleteTrashBinCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteTrashBinCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashBins.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashBin), request.Id);

            _dbContext.TrashBins.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
