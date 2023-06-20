using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.DeleteTrashType
{
    public class DeleteTrashTypeCommandHandler : IRequestHandler<DeleteTrashTypeCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public DeleteTrashTypeCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteTrashTypeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashType), request.Id);

            _dbContext.TrashTypes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
