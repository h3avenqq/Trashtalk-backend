using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.DeleteUserTrash
{
    public class DeleteUserTrashCommandHandler : IRequestHandler<DeleteUserTrashCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public DeleteUserTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserTrashCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.UserTrash.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Domain.UserTrash), request.Id);

            _dbContext.UserTrash.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
