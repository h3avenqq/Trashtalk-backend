using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.DeleteReceptionPoint
{
    public class DeleteReceptionPointCommandHandler : IRequestHandler<DeleteReceptionPointCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public DeleteReceptionPointCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteReceptionPointCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ReceptionPoints.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(ReceptionPoint), request.Id);

            _dbContext.ReceptionPoints.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
