using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.Trash.Commands.CreateTrash
{
    public class CreateTrashCommandHandler : IRequestHandler<CreateTrashCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Guid> IRequestHandler<CreateTrashCommand, Guid>.Handle(CreateTrashCommand request, CancellationToken cancellationToken)
        {
            var trash = new Domain.Trash
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Barcode = request.Barcode,
                Weight = request.Weight,
                TypeId = request.TypeId
            };

            await _dbContext.Trash.AddAsync(trash);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return trash.Id;
        }
    }
}
