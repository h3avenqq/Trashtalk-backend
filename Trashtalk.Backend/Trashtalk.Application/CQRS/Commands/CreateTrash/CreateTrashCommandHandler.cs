using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.Commands.CreateTrash
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
            var trash = new Trash
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Barcode = request.Barcode,
                TypeId = request.TypeId
            };

            await _dbContext.Trash.AddAsync(trash);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return trash.Id;
        }
    }
}
