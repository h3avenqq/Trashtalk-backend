using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trashtalk.Application.CQRS.TrashBins.Commands.DeleteTrashBin;

namespace Trashtalk.Application.CQRS.Trash.Commands.UpdateTrash
{
    public class UpdateTrashCommandValidator : AbstractValidator<UpdateTrashCommand>
    {
        public UpdateTrashCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Barcode).NotEmpty().Matches(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
            RuleFor(x => x.Weight).NotNull().Must(x => x > 0);
        }
    }
}
