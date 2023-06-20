using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.TrashBins.Queries.GetTrashBinList
{
    public class TrashBinListVm
    {
        public IList<TrashBinLookupDto> TrashBins { get; set; }
    }
}
