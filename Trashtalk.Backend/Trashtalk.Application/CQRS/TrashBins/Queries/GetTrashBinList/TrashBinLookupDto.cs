using System;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinList
{
    public class TrashBinLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
