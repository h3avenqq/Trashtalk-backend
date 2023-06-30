using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;
using NetTopologySuite.Geometries;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.UpdateReceptionPoint
{
    public class UpdateReceptionPointCommandHandler : IRequestHandler<UpdateReceptionPointCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateReceptionPointCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateReceptionPointCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ReceptionPoints.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(ReceptionPoint), request.Id);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Address = request.Address;
            entity.Coordinates = new Point(request.Coordinates.X, request.Coordinates.Y);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
