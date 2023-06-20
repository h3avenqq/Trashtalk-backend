using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.TrashTypes.Commands.CreateTrashType
{
    public class CreateTrashTypeCommandHandler : IRequestHandler<CreateTrashTypeCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateTrashTypeCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateTrashTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new TrashType()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Algorithm = request.Algorithm,
                TrashBinId = request.TrashBinId
            };

            await _dbContext.TrashTypes.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
