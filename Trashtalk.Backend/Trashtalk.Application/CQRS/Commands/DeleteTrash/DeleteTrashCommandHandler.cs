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

namespace Trashtalk.Application.CQRS.Commands.DeleteTrash
{
    public class DeleteTrashCommandHandler : IRequestHandler<DeleteTrashCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public DeleteTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteTrashCommand request, CancellationToken cancellationToken)
        {
            var entity
                = await _dbContext.Trash.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trash), request.Id);

            _dbContext.Trash.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
