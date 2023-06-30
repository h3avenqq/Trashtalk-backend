using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateNewsCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.News), request.Id);

            entity.Id = request.Id;
            entity.Title = request.Title;
            entity.BriefDescription = request.BriefDescription;
            entity.Description = request.Description;
            entity.EditDate = DateTime.UtcNow;
            entity.AuthorId = request.AuthorId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
