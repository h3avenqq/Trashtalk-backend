using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash
{
    public class UpdateTrashCommandHandler : IRequestHandler<UpdateTrashCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTrashCommand request, CancellationToken cancellationToken)
        {
            var entity 
                = await _dbContext.Trash.FirstOrDefaultAsync(x => 
                    x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trash), request.Id);

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Barcode = request.Barcode;
            entity.Weight = request.Weight;
            entity.TypeId = request.TypeId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
