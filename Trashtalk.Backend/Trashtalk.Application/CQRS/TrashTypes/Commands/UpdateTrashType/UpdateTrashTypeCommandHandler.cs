using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.UpdateTrashType
{
    public class UpdateTrashTypeCommandHandler : IRequestHandler<UpdateTrashTypeCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateTrashTypeCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTrashTypeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.TrashTypes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(TrashType), request.Id);

            entity.Name = request.Name;
            entity.Algorithm = request.Algorithm;
            entity.TrashBinId = request.TrashBinId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
