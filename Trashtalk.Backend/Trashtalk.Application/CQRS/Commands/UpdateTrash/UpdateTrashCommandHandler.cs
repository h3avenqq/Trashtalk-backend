﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trashtalk.Application.Common.Exceptions;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;

namespace Trashtalk.Application.CQRS.Commands.UpdateTrash
{
    public class UpdateTrashCommandHandler : IRequestHandler<UpdateTrashCommand>
    {
        private readonly ITrashTalkDbContext _dbContext;

        public UpdateTrashCommandHandler(ITrashTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateTrashCommand request, CancellationToken cancellationToken)
        {
            var entity 
                = await _dbContext.Trash.FirstOrDefaultAsync(x => 
                    x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trash), request.Id);

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Barcode = request.Barcode;
            entity.TypeId = request.TypeId;

            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
