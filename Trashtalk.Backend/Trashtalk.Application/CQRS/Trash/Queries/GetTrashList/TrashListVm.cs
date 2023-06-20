using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.Trash.Queries.GetTrashList
{
    public class TrashListVm
    {
        public IList<TrashLookupDto> Trash { get; set; } 
    }
}
