using System;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList
{
    public class TrashTypeLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public Guid TrashBinId { get; set; }
    }
}
