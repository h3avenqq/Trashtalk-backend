using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeDetails
{
    public class TrashTypeDetailsVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }
    }
}
