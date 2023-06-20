using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashBins.Commands.CreateTrashBin
{
    public class CreateTrashBinCommandHandler : IRequestHandler<CreateTrashBinCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateTrashBinCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateTrashBinCommand request, CancellationToken cancellationToken)
        {
            var entity = new TrashBin()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Color = request.Color
            };

            await _dbContext.TrashBins.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
