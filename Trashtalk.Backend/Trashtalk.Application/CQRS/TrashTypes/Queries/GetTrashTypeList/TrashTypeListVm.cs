using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.TrashTypes.Queries.GetTrashTypeList
{
    public class TrashTypeListVm
    {
        public IList<TrashTypeLookupDto> TrashTypes { get; set; }
    }
}
