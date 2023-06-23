using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Application.CQRS.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public CreateNewsCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.News()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                BriefDescription = request.BriefDescription,
                Description = request.Description,
                PublishDate = DateTime.Now,
                EditDate = null,
                AuthorId = request.AuthorId
            };

            await _dbContext.News.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
