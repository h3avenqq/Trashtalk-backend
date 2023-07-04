using MediatR;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashDetails
{
    public class GetTrashDetailsQuery : IRequest<TrashDetailsVm>
    {
        public string Barcode { get; set; }
    }
}
