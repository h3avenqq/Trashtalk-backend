using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.ReceptionPoints.Commands.CreateReceptionPoint
{
    public class CreateReceptionPointCommandHandler : IRequestHandler<CreateReceptionPointCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateReceptionPointCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateReceptionPointCommand request, CancellationToken cancellationToken)
        {
            var entity = new ReceptionPoint()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                Coordinates = request.Coordinates
            };

            await _dbContext.ReceptionPoints.AddAsync(entity,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
