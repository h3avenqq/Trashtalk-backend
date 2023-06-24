using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.UserTrash.Commands.CreateUserTrash
{
    public class CreateUserTrashCommandHandler : IRequestHandler<CreateUserTrashCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateUserTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserTrashCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.UserTrash()
            {
                Id = Guid.NewGuid(),
                TrashId = request.TrashId,
                UserId = request.UserId,
                Country = request.Country,
                Region = request.Region,
                City = request.City,
                District = request.District,
                Time = DateTime.Now
            };

            await _dbContext.UserTrash.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
