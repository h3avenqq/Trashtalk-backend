using System.Collections.Generic;

namespace Trashtalk.Application.CQRS.Queries.GetTrashList
{
    public class TrashListVm
    {
        public IList<TrashLookupDto> Trash { get; set; } 
    }
}
